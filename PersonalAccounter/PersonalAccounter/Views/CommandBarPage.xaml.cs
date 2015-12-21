namespace PersonalAccounter.Views
{
    using Models;
    using ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;
    using Windows.UI.Xaml.Input;

    public sealed partial class CommandBarPage : Page
    {
        private ExpenseViewModel expenses;
        private Category selected;

        public CommandBarPage()
        {
            this.InitializeComponent();
            this.expenses = new ExpenseViewModel();

            NavigationCacheMode = NavigationCacheMode.Required;
        }

        public void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
            myFlyout.Hide();
        }

        private void UIElement_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (topbar.Opacity == 0.0)
            {
                ShowStoryboard.Begin();
            }
            else
            {
                HideStoryboard.Begin();
            }
        }

        private void Confirm_OnClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (ExpensePage));
        }

        private void Household_OnChecked(object sender, RoutedEventArgs e)
        {
            if (this.Household.IsChecked.Value)
            {
                var category = Category.Household;
                selected = category;

            }
            else if (this.Lifestyle.IsChecked.Value)
            {
                var category = Category.Lifestyle;
                selected = category;
            }
            else
            {
                var category = Category.Unexpected;
                selected = category;
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var name = this.tbName.Text;
            var cost = this.tbCost.Value;
            var description = this.tbDesc.Text;
            var imageUrl = this.tbImage.Text;
            var category = selected;

            this.expenses.AddExpense(name, imageUrl, description, cost, selected);
        }
    }
}

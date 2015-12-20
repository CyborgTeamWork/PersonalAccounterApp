using Windows.UI.Xaml.Input;

namespace PersonalAccounter.Views
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using PersonalAccounter.ViewModels;

    public sealed partial class BudgetPage : Page
    {
        private BudgetViewModel budgetVM;   
        public BudgetPage()
        {
            this.InitializeComponent();
            this.budgetVM = new BudgetViewModel();
        }

        private void MyBudgetSettingClick(object sender, RoutedEventArgs e)
        {
            var overall = slBudget.Value;
            var household = slHome.Value;
            var lifestyle = slLife.Value;
            var unexpected = slUnex.Value;
            this.budgetVM.EditMyBudget(overall, household,lifestyle,unexpected);
            
            this.Frame.Navigate(typeof(BudgetDisplayPage));
        }

        private void MyBudgetCancelClick(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(BudgetDisplayPage));
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
    }
}

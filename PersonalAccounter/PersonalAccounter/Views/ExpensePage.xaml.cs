namespace PersonalAccounter.Views
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using PersonalAccounter.ViewModels;
    using System.Collections.ObjectModel;
    using Windows.UI.Xaml.Input;
    using PersonalAccounter.Models;

    public sealed partial class ExpensePage : Page
    {
        private ExpensePage rootPage;

        public ExpensePage()
        {
            this.InitializeComponent();
            this.DataContext = new ExpenseViewModel();
        }

        public ObservableCollection<Expense> Expenses { get; set; } 

        public void NavigateToAddViewClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (CommandBarPage));
        }


        private void UIElement_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (topbar.Opacity == 0)
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


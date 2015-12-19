namespace PersonalAccounter.Views
{
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using PersonalAccounter.ViewModels;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BudjetPage : Page
    {
        public BudjetPage()
        {
            this.InitializeComponent();
            var contentViewModel = new BudjetContentViewModel();

            contentViewModel.MonthlyBudjets = new List<BudjetViewModel>()
            {
                new BudjetViewModel(3000, 1500, 1000, 500),
            };

            this.DataContext = new MainPageViewModel(contentViewModel);
        }

        private void MyBudjetSettingClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BudjetPage));
        }

        private void MyBudjetDtailsClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(UnexpectedPage));
        }
    }
}

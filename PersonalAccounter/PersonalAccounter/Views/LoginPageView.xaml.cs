namespace PersonalAccounter.Views
{
    using System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using PersonalAccounter.ViewModels;

    public sealed partial class LoginPageView : Page
    {
        private UserViewModel userViewModel = new UserViewModel();
        public LoginPageView()
        {
            this.InitializeComponent();
            this.DataContext = userViewModel;
        }

        private async void SignInClick(object sender, RoutedEventArgs e)
        {
            string username = id.Text;
            string password = pwd.Password;
            this.userViewModel.Register(username, password);
            this.Frame.Navigate(typeof(BudgetPage));
        }

        private void Button_Toggle_Click_Login(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (AppShell));
        }
    }
}

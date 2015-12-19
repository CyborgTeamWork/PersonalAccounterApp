namespace PersonalAccounter.Views
{
    using System;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Parse;
    using PersonalAccounter.Models;
    using PersonalAccounter.Models.Repository;
    using PersonalAccounter.ViewModels;
    using SQLite.Net;
    using SQLite.Net.Async;
    using SQLite.Net.Platform.WinRT;
    using WinRTXamlToolkit.Controls.Extensions;
    using PersonalAccounter.Helpers;

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
            this.Frame.Navigate(typeof(BudgetDisplayPage));
            var successMessage = new MessageDialog("You successfully signed in!");
            await successMessage.ShowAsync();
        }

        private void Button_Toggle_Click_Login(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (AppShell));
        }
    }
}

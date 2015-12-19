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

        private void Button_Toggle_Click_Login(object sender, RoutedEventArgs e)
        {
            if (!logincontrol1.IsOpen)
            {
                parent.IsEnabled = false;
                this.Opacity = .4;
                container.IsEnabled = true;
                logincontrol1.IsOpen = true;
                pop.Width = Window.Current.Bounds.Width;
            }
            else
            {
                logincontrol1.IsOpen = false;
                this.Opacity = 1.0;
                parent.IsEnabled = true;
            }
        }

        private async void SignInClick(object sender, RoutedEventArgs e)
        {
            if (Validations.ValidateLoginForm(id.Text, pwd.Password))
            {
                var errormMessage = new MessageDialog("Wrong email/password!");
                await errormMessage.ShowAsync();

                return;
            }
            string username = id.Text;
            string password = pwd.Password;
            userViewModel.Register(username, password);
            var usersTask = userViewModel.GetUsers();
            var usersResult = usersTask.Result;
            this.Frame.Navigate(typeof(BudgetDisplayPage));
            var successMessage = new MessageDialog("You successfully signed in!");
            await successMessage.ShowAsync();
        }
    }
}

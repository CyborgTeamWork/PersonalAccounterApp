using System;
using System.IO;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Parse;
using PersonalAccounter.Models;
using PersonalAccounter.Models.Repository;
using PersonalAccounter.ViewModels;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using WinRTXamlToolkit.Controls.Extensions;

namespace PersonalAccounter.Views
{
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
            string username = id.Text;
            string password = pwd.Password;
            userViewModel.RegisterUser(username, password);
            this.Frame.Navigate(typeof(BudgetDisplayPage));
            var successMessage = new MessageDialog("You successfully signed in!");
            await successMessage.ShowAsync();
        }
    }
}

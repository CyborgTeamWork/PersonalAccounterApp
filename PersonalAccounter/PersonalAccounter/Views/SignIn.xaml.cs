using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using PersonalAccounter.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PersonalAccounter.Views
{
    public sealed partial class SignIn : Page
    {
        private UserViewModel userViewModel = new UserViewModel();
        public SignIn()
        {
            this.InitializeComponent();
            this.DataContext = userViewModel;
        }

        private async void SignInClick(object sender, RoutedEventArgs e)
        {
            string username = id.Text;
            string password = pwd.Password;
            this.userViewModel.SignIn(username, password);
            this.Frame.Navigate(typeof(BudgetDisplayPage));
        }

        private void Button_Toggle_Click_Login(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AppShell));
        }
    }
}

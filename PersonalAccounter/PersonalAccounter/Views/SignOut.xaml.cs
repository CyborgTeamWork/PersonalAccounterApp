using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using PersonalAccounter.ViewModels;

namespace PersonalAccounter.Views
{
    public sealed partial class SignOut : Page
    {
        private UserViewModel userViewModel = new UserViewModel();
        private AppShell page = new AppShell();
        public SignOut()
        {
            this.InitializeComponent();
            this.DataContext = userViewModel;
        }

        private void SignOutClick(object sender, RoutedEventArgs e)
        {
            this.userViewModel.SignOut();
            this.page.LoadMenu();
            this.Frame.Navigate(typeof (SignIn));
        }

        private void Button_Toggle_Click_Login(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AppShell));
        }
    }
}

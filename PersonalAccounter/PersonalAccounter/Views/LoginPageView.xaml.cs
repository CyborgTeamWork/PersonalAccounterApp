using PersonalAccounter.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PersonalAccounter.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPageView : Page
    {
        public LoginPageView()
        {
            this.InitializeComponent();

            this.DataContext = new UserViewModel("pesho@abv.bg", "password");
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
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
    }
}

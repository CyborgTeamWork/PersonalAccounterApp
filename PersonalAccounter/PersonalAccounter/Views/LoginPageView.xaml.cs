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

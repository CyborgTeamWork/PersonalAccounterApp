using PersonalAccounter.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PersonalAccounter.Views
{
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

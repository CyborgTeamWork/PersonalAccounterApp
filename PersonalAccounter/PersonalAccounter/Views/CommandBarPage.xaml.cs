namespace PersonalAccounter.Views
{
    using System;
    using Windows.UI.Popups;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using PersonalAccounter.Helpers;
    using PersonalAccounter.ViewModels;

    public sealed partial class CommandBarPage : Page
    {
        public CommandBarPage()
        {
            this.InitializeComponent();

            this.DataContext = new CommandBarPageViewModel();
        }

        public void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
            myFlyout.Hide();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validations.ValidateString(this.tbName.Text, 2, 50))
            {
                var errormMessage = new MessageDialog("Name must be within 2 and 50 alphabetic symbols!");
                await errormMessage.ShowAsync();

                return;
            }

            if (Validations.ValidateString(this.tbDesc.Text, 0, 100))
            {
                var errormMessage = new MessageDialog("Description can't be more then 100 symbols!");
                await errormMessage.ShowAsync();

                return;
            }
        }
    }
}

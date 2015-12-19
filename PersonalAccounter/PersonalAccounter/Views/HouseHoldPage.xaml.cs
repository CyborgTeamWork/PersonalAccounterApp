namespace PersonalAccounter.Views
{
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using PersonalAccounter.ViewModels;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HouseHoldPage : Page
    {
        private HouseHoldPage rootPage;

        public HouseHoldPage()
        {
            this.InitializeComponent();
            var contentViewModel = new HouseHoldContentViewModel();

            contentViewModel.HouseHoldExpenses = new List<HouseHoldViewModel>()
            {
                new HouseHoldViewModel("Monthly Rent", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrg6z1AXbFQ7pXxKt474ZOtcuonPKfAWsa5e5KBLGFybW6nNvN", 500, "Sheduled for 15th"),
                new HouseHoldViewModel("Electricity Bill", "http://www.electricitynews.co/wp-content/uploads/2015/09/Electricity.jpg", 120, "... pay on5th day of the month"),
                new HouseHoldViewModel("Internet Bill", "http://live-thedailyvoice.time.ly/wp-content/uploads/2015/10/14821565-Internet-world-wide-web-concept-Earth-globe-with-www-text-and-computer-hand-cursor-isolated-on-white-Stock-Photo.jpg", 25, "THE NET!"),
                new HouseHoldViewModel("Monthly Rent", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrg6z1AXbFQ7pXxKt474ZOtcuonPKfAWsa5e5KBLGFybW6nNvN", 500, "Sheduled for 15th"),
                new HouseHoldViewModel("Electricity Bill", "http://www.electricitynews.co/wp-content/uploads/2015/09/Electricity.jpg", 120, "... pay on5th day of the month"),
                new HouseHoldViewModel("Internet Bill", "http://live-thedailyvoice.time.ly/wp-content/uploads/2015/10/14821565-Internet-world-wide-web-concept-Earth-globe-with-www-text-and-computer-hand-cursor-isolated-on-white-Stock-Photo.jpg", 25, "THE NET!"),
                new HouseHoldViewModel("Monthly Rent", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrg6z1AXbFQ7pXxKt474ZOtcuonPKfAWsa5e5KBLGFybW6nNvN", 500, "Sheduled for 15th"),
                new HouseHoldViewModel("Electricity Bill", "http://www.electricitynews.co/wp-content/uploads/2015/09/Electricity.jpg", 120, "... pay on5th day of the month"),
                new HouseHoldViewModel("Internet Bill", "http://live-thedailyvoice.time.ly/wp-content/uploads/2015/10/14821565-Internet-world-wide-web-concept-Earth-globe-with-www-text-and-computer-hand-cursor-isolated-on-white-Stock-Photo.jpg", 25, "THE NET!"),
            };

            this.DataContext = new MainPageViewModel(contentViewModel);
        }

        public void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}


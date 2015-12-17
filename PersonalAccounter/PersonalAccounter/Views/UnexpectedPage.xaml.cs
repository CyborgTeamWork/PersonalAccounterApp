namespace PersonalAccounter.Views
{
    using System.Collections.Generic;
    using PersonalAccounter.ViewModels;

    using PersonalAccounter.ViewModels.PersonalAccounter.ViewModels;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UnexpectedPage : Page
    {
        public UnexpectedPage()
        {
            this.InitializeComponent();
            var contentViewModel = new UnexpectedExpensesContentViewModel();

            contentViewModel.UnexpectedExpenses = new List<UnexpectedExpensesViewModel>()
            {
                new UnexpectedExpensesViewModel("Child excursion", "http://www.tunisiaonline.com/wp-content/uploads/2013/11/16.jpg", 250, "Gotta to pay before the end of the month"),
                new UnexpectedExpensesViewModel("Ill father", "http://i.dailymail.co.uk/i/pix/2011/11/19/article-2063512-00630D071000044C-648_468x356.jpg", 50, "For pills"),
                new UnexpectedExpensesViewModel("New tyres", "http://www.berrystreetgarage.com/wp-content/uploads/2012/06/service-tyres.jpg", 200, "Winter tyres needed"),
                new UnexpectedExpensesViewModel("Child excursion", "http://www.tunisiaonline.com/wp-content/uploads/2013/11/16.jpg", 250, "Gotta to pay before the end of the month"),
                new UnexpectedExpensesViewModel("Ill father", "http://i.dailymail.co.uk/i/pix/2011/11/19/article-2063512-00630D071000044C-648_468x356.jpg", 50, "For pills")
            };

            this.DataContext = new MainPageViewModel(contentViewModel);
        }

        public void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
            // some real delete action to be added 
        }
    }
}


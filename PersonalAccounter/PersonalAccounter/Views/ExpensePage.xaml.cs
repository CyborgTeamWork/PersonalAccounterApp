using System.Collections.ObjectModel;
using PersonalAccounter.Models;

namespace PersonalAccounter.Views
{
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using PersonalAccounter.ViewModels;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ExpensePage : Page
    {
        private ExpensePage rootPage;

        public ExpensePage()
        {
            this.InitializeComponent();
            this.DataContext = new ExpenseViewModel();
        }

        public ObservableCollection<Expense> Expenses { get; set; } 

        public void NavigateToAddViewClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (CommandBarPage));
        }

        public void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}


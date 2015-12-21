namespace PersonalAccounter.Views
{
    using Windows.UI.Xaml.Input;
    using ViewModels;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using WinRTXamlToolkit.Controls.DataVisualization.Charting;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BudgetDisplayPage : Page
    {
        private ExpenseViewModel expenses;
        public BudgetDisplayPage()
        {

            this.InitializeComponent();
            this.expenses = new ExpenseViewModel();
            this.PopulateChart();
        }

        public async void PopulateChart()
        {
            var myList = await this.expenses.EditChart();
            (MyExpenses.Series[0] as PieSeries).ItemsSource = myList;
        }
        private void MyBudgetSettingClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BudgetPage));
        }

        private void UIElement_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (topbar.Opacity == 0.0)
            {
                ShowStoryboard.Begin();
            }
            else
            {
                HideStoryboard.Begin();
            }
        }
    }
}

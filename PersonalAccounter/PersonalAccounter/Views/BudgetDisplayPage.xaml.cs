namespace PersonalAccounter.Views
{
    using System;
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using WinRTXamlToolkit.Controls.DataVisualization.Charting;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BudgetDisplayPage : Page
    {
        public BudgetDisplayPage()
        {
            this.InitializeComponent();

            List<Tuple<string, int>> myList = new List<Tuple<string, int>>()
    {
        new Tuple<string, int>("Household", 20),
        new Tuple<string, int>("Lifestyle", 30),
        new Tuple<string, int>("Unexpected", 50)
    };

            (MyExpenses.Series[0] as PieSeries).ItemsSource = myList;
        }

        private void MyBudgetSettingClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BudjetPage));
        }
    }
}

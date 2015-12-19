namespace PersonalAccounter.ViewModels
{
    using Helpers.ViewModelHelpers;

    public class BudgetViewModel : ViewModelBase
    {
        private BudgetViewModelHelpers budgets;

        public BudgetViewModel() 
        {
            this.budgets = new BudgetViewModelHelpers();

        }

        public async void EditMyBudget(double overall, double household, double lifestyle, double unexpected)
        {
            this.budgets.UpdateBudget(overall, household, lifestyle, unexpected);
        }

        public async void SetPieChart()
        {
            //TODO
        }
    }
}

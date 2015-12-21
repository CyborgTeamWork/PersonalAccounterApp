using System;
using Parse;
using PersonalAccounter.Models.Parse;

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

        public async void CreateNewBudget(double overall, double household, double lifestyle, double unexpected)
        {
            this.budgets.CreateNewBudgetLocally(overall, household,lifestyle,unexpected);
            this.budgets.CreateNewBudgetInParse(overall, household,lifestyle,unexpected);
            
        }

        //public async void EditMyBudget(double overall, double household, double lifestyle, double unexpected)
        //{
        //    this.budgets.UpdateBudgetLocally(overall, household, lifestyle, unexpected);
        //    this.budgets.UpdateBudgetParse(overall, household,lifestyle,unexpected);
        //}
    }
}

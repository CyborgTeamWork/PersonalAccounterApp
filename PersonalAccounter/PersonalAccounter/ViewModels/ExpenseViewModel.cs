using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using PersonalAccounter.Helpers.ViewModelHelpers;
using PersonalAccounter.Models;

namespace PersonalAccounter.ViewModels
{
    public class ExpenseViewModel : ViewModelBase
    {
        private ExpenseViewModelHelper expenses;

        public ExpenseViewModel()
        {
            this.expenses = new ExpenseViewModelHelper();
        }

        public void AddExpense(string name, string imageUrl, string description, double price, Category category)
        {
            this.expenses.AddNewExpense(name, imageUrl,description,price,category);
        }

        public async void Display()
        {
           await this.expenses.Get();
        }

        public void Edit()
        {
            
        }
    }
}

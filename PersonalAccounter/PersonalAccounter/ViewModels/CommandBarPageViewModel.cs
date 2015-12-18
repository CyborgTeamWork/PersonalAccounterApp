using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalAccounter.Models;
using PersonalAccounter.Models.Repository;
using PersonalAccounter.Models.SQLite.Repository;

namespace PersonalAccounter.ViewModels
{
    public class CommandBarPageViewModel
    {
        private IRepository<Expense> expenses;

        public CommandBarPageViewModel()
        {
            this.expenses = GenericRepostory<Expense>.Repostory;
        }

        public async void CreateExpense(string name, string imageUrl, float coast, string description, Category category)
        {
            var newExpense = new Expense
            {
                Category = category,
                Coast = coast,
                Description = description,
                ImageUrl = imageUrl,
                Name = name
            };

            await this.expenses.Insert(newExpense);
        }

        public async void DeleteExpense(Expense expense)
        {
            await this.expenses.Delete(expense);
        }
    }
}

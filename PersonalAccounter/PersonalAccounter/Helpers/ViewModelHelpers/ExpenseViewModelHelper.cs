using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PersonalAccounter.Helpers.ViewModelHelpers
{
    using PersonalAccounter.Models;
    using PersonalAccounter.Models.SQLite.Repository;
    using System.Threading.Tasks;
    using Parse;
    using PersonalAccounter.Models.Repository;

    public class ExpenseViewModelHelper
    {
        private IRepository<Expense> expenses;
        private UserViewModelHelper users; 

        public ExpenseViewModelHelper()
        {
            this.expenses = GenericRepostory<Expense>.Repostory;
            this.users = new UserViewModelHelper();
        }

        public async void AddNewExpense(string name, string imageUrl, string description, double price, Category category)
        {
            var expense = new Expense
            {
                Name = name,
                Category = category,
                Coast = price,
                Description = description,
                ImageUrl = imageUrl,
                UserId = await this.GetUserId()
            };

            this.expenses.Insert(expense);
        }

        public async void EditExpense()
        {
            
        }

        public async Task<int> GetUserId()
        {
            var current = ParseUser.CurrentUser.Username;
            var userCollection = await users.Get();

            var user = userCollection
                    .Where(u => u.Username == current)
                    .FirstOrDefault();
            var userId = user.Id;
            return userId;
        }

        public async Task<ObservableCollection<Expense>> Get()
        {
            var collection = await this.expenses.Get();
            var expensesToDisplay = new ObservableCollection<Expense>();
            foreach (var item in collection)
            {
                expensesToDisplay.Add(item);
            }

            return expensesToDisplay;
        }
    }
}
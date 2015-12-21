using System;
using Windows.UI.Popups;
using PersonalAccounter.Models.SQLite;

namespace PersonalAccounter.Helpers.ViewModelHelpers
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Models.Parse;
    using Models.Repository;
    using Models.SQLite.Repository;
    using Parse;

    public class ExpenseViewModelHelper
    {
        private IRepository<Expense> expenses;
        private UserViewModelHelper users;
        private IRepository<Budget> budget; 

        public ExpenseViewModelHelper()
        {
            this.expenses = GenericRepostory<Expense>.Repostory;
            this.users = new UserViewModelHelper();
            //this.connection = new CheckConnection();
            this.budget = GenericRepostory<Budget>.Repostory;
        }

        public async void AddNewExpenseLocally(string name, string imageUrl, string description, double price, Category category)
        {
            var expense = new Expense
            {
                Name = name,
                Category = category,
                Coast = price,
                Description = description,
                ImageUrl = imageUrl,
                CreatedOn = DateTime.Now,
                UserId = await this.GetUserId()
            };

            this.expenses.Insert(expense);

            var successMessage = new MessageDialog("You successfully added a new expense");
            await successMessage.ShowAsync();
        }

        public async void AddExpenseParse(string name, string imageUrl, string description, double price,
            Category category)
        {
            var newExpense = ParseObject.Create<ExpenseParse>();
            newExpense = new ExpenseParse
            {
                Name = name,
                ImageUrl = imageUrl,
                Description = description,
                Price = price
            };
            var selected = await ParseObject.GetQuery("CategoryParse")
                    .WhereContains("Name", category.ToString()).FirstOrDefaultAsync() as CategoryParse;

            if (selected == null)
            {
                selected = ParseObject.Create<CategoryParse>();
                selected.Expenses = new List<ExpenseParse>();
            }

            UserParse user = (UserParse)ParseUser.CurrentUser;
            if (user.Expenses == null)
            {
                user.Expenses = new List<ExpenseParse>();
            }

            ParseUser.CurrentUser.AddToList("Expenses", newExpense);
            selected.AddToList("Expenses", newExpense);
            await ParseUser.CurrentUser.SaveAsync();
            await selected.SaveAsync();
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

        public async Task<List<Tuple<string, double>>> PopulatingChart()
        {
            var household = await this.expenses
                .AsQueryable()
                .Where(e => e.Category == Category.Household)
                .Where(e => e.CreatedOn - DateTime.Now >= TimeSpan.Zero).ToListAsync();
            double householdSum = 0;
            if (household.Count == 0)
            {
                var selectedBudget = await this.SelectedBudget();
                householdSum = selectedBudget.HouseholdExpectancy;
            }
            else
            {
                foreach (var expense in household)
                {
                    householdSum += expense.Coast;
                }
            }

            var lifestyle = await this.expenses
                .AsQueryable()
                .Where(e => e.Category == Category.Lifestyle)
                .Where(e => e.CreatedOn - DateTime.Now >= TimeSpan.Zero).ToListAsync();
            double lifestyleSum = 0;
            if (lifestyle.Count == 0)
            {
                var selectedBudget = await this.SelectedBudget();
                lifestyleSum = selectedBudget.HouseholdExpectancy;
            }
            else
            {
                foreach (var expense in lifestyle)
                {
                    lifestyleSum += expense.Coast;
                }
            }

            var unexpected = await this.expenses
                .AsQueryable()
                .Where(e => e.Category == Category.Unexpected)
                .Where(e => e.CreatedOn - DateTime.Now >= TimeSpan.Zero).ToListAsync();
            double unexpectedSum = 0;
            if (household.Count == 0)
            {
                var selectedBudget = await this.SelectedBudget();
                unexpectedSum = selectedBudget.UnexpectedExpectancy;
            }
            else
            {
                foreach (var expense in unexpected)
                {
                    unexpectedSum += expense.Coast;
                }
            }

            var list = new List<Tuple<string, double>>();
            list.Add(new Tuple<string, double>("Household", householdSum));
            list.Add(new Tuple<string, double>("Lifestyle", lifestyleSum));
            list.Add(new Tuple<string, double>("Unexpected", unexpectedSum));

            return list;
        }

        public async Task<Budget> SelectedBudget()
        {
            var userId = await this.GetUserId();
            var selectedBudget = await this.budget
                .AsQueryable()
                .Where(b => b.UserId == userId)
                .FirstOrDefaultAsync();
            return selectedBudget;
        }
    }
}
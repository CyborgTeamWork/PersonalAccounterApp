using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parse;
using PersonalAccounter.Models;
using PersonalAccounter.Models.Parse;
using PersonalAccounter.Models.Repository;
using PersonalAccounter.Models.SQLite;
using PersonalAccounter.Models.SQLite.Repository;

namespace PersonalAccounter.Helpers.ViewModelHelpers
{
    public class BudgetViewModelHelpers
    {
        private IRepository<Budget> budgets;
        private IRepository<User> users;

        public BudgetViewModelHelpers()
        {
            budgets = GenericRepostory<Budget>.Repostory;
            users = GenericRepostory<User>.Repostory;
        }

        public async void CreateNewBudget(User user)
        {
            var budget = new Budget
            {
                Overall = 0.00,
                HouseholdExpectancy = 0.00,
                LifestyleExpectancy = 0.00,
                UnexpectedExpectancy = 0.00,
                UserId = user.Id
            };

            await this.budgets.Insert(budget);
        }

        public async void CreateNewBudgetInParse(UserParse user)
        {
            var newBudget = ParseObject.Create<BudgetParse>();
            newBudget = new BudgetParse
            {
                Overall = 0.00,
                HouseholdExpectancy = 0.00,
                LifestyleExpectancy = 0.00,
                UnexpectedExpectancy = 0.00,
                Saved = 0.00,
            };

            user.Add("Budget", newBudget);
            await newBudget.SaveAsync();

        }

        public async Task<List<Budget>> Get()
        {
            return await this.budgets.Get();
        }

        public async void UpdateBudget(double overall, double household, double lifestyle, double unexpected)
        {
            var userId = await this.GetUserId();
            var allBudgets = await this.budgets.Get();
            var selected = allBudgets
                    .Where(b => b.UserId == userId)
                    .FirstOrDefault();
            selected.Overall = overall;
            selected.HouseholdExpectancy = household;
            selected.LifestyleExpectancy = lifestyle;
            selected.UnexpectedExpectancy = unexpected;
            selected.Saved = overall - household - lifestyle - unexpected;
            await this.budgets.Update(selected);
        }


        public async Task<int> GetUserId()
        {
            var current = ParseUser.CurrentUser.Username;
            var userCollection = await users.Get();
            
            var user = userCollection
                    .Where(u => u.Username == current)
                    .FirstOrDefault();
            var  userId = user.Id;
            return userId;
        }
    }
}

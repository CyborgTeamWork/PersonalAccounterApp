using System;

namespace PersonalAccounter.Helpers.ViewModelHelpers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Parse;
    using Models;
    using Models.Parse;
    using Models.Repository;
    using Models.SQLite;
    using Models.SQLite.Repository;
    public class BudgetViewModelHelpers
    {
        private IRepository<Budget> budgets;
        private IRepository<User> users;
       // private CheckConnection connection;

        public BudgetViewModelHelpers()
        {
            this.budgets = GenericRepostory<Budget>.Repostory;
            this.users = GenericRepostory<User>.Repostory;
           // this.connection = new CheckConnection();
        }

        public async void CreateNewBudgetLocally(double overall, double household, double lifestyle, double unexpected)
        {
            var userId = await this.GetUserId();
            var budget = new Budget
            {
                Overall = overall,
                HouseholdExpectancy = household,
                LifestyleExpectancy = lifestyle,
                UnexpectedExpectancy = unexpected,
                Saved = overall - household - lifestyle - unexpected,
                UserId = userId
            };

            await this.budgets.Insert(budget);
        }

        public async void CreateNewBudgetInParse(double overall, double household, double lifestyle, double unexpected)
        {
            var currentUser = (UserParse)ParseUser.CurrentUser;
                var newBudget = ParseObject.Create<BudgetParse>();
                newBudget = new BudgetParse
                {
                    Overall = overall,
                    HouseholdExpectancy = household,
                    LifestyleExpectancy = lifestyle,
                    UnexpectedExpectancy = unexpected,
                    Saved = overall - household - lifestyle - unexpected,
                };

                currentUser.Add("Budget", newBudget);
                await newBudget.SaveAsync();
        }

        public async Task<List<Budget>> Get()
        {
            return await this.budgets.Get();
        }

        //public async void UpdateBudgetLocally(double overall, double household, double lifestyle, double unexpected)
        //{
        //    var userId = await this.GetUserId();
        //    var allBudgets = await this.budgets.Get();
        //    var selected = allBudgets
        //            .Where(b => b.UserId == userId)
        //            .FirstOrDefault();
        //    selected.Overall = overall;
        //    selected.HouseholdExpectancy = household;
        //    selected.LifestyleExpectancy = lifestyle;
        //    selected.UnexpectedExpectancy = unexpected;
        //    selected.Saved = overall - household - lifestyle - unexpected;
        //    await this.budgets.Update(selected);
        //}

        //public async void UpdateBudgetParse(double overall, double household, double lifestyle, double unexpected)
        //{
        //    var parseUser = (UserParse)ParseUser.CurrentUser;
        //    parseUser.Budget.Overall = overall;
        //    parseUser.Budget.HouseholdExpectancy = household;
        //    parseUser.Budget.LifestyleExpectancy = lifestyle;
        //    parseUser.Budget.UnexpectedExpectancy = unexpected;
        //    await parseUser.SaveAsync();
        //}


        public async Task<int> GetUserId()
        {
            var current = (UserParse)ParseUser.CurrentUser;
            var username = current.Username;
            var userCollection = await this.users.Get();
            var user = userCollection
                    .Where(u => u.Username == username)
                    .FirstOrDefault();
            var  userId = user.Id;
            return userId;
        }

        public async Task<int> CalculateAngle()
        {
            var userId = await this.GetUserId();

            var collection = await this.budgets.Get();
            var selected = collection.
                    FirstOrDefault(b => b.UserId == userId);
            var createdOn = selected.CreatedOn;
            DateTime current = DateTime.Now;
            TimeSpan days = new TimeSpan(30);
            TimeSpan data = current - createdOn; 
            return (int.Parse(data.ToString()) % 30);
        }
    }
}

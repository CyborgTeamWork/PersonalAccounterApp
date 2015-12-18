using System;
using Parse;
using PersonalAccounter.Models;
using PersonalAccounter.Models.Parse;
using PersonalAccounter.Models.SQLite.Repository;

namespace PersonalAccounter.ViewModels
{
    public class UserViewModel
    {
        private IRepository<User> users;

        public UserViewModel()
        {
            //this.users = GenericRepostory<User>.Repostory;
        }

        private void PullDataFromParse()
        {
            throw new NotImplementedException();
        }

        public async void RegisterUser(string username,string password)
        {
            var newUser = new ParseUser
            {
                Username = username,
                Password = password
            };

            await newUser.SignUpAsync();
            if (newUser.IsNew)
            {
                //newUser.SaveAsync();
                await ParseUser.LogInAsync(username, password);
                var userId = newUser.ObjectId;
                ParseObject.RegisterSubclass<BudgetParse>();
                var  newBudget = ParseObject.Create<BudgetParse>();
                newBudget = new BudgetParse
                {
                    Overall = 0.00,
                    HouseholdExpectancy = 0.00,
                    LifestyleExpectancy = 0.00,
                    UnexpectedExpectancy = 0.00,
                    Saved = 0.00,
                };
                newBudget.GetRelation<ParseUser>(userId);
                await newBudget.SaveAsync();
            }
        }
    }
}

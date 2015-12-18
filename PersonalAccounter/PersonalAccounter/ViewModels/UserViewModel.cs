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

        public async void RegisterUser(string username,string password)
        {
            var newUser = ParseUser.Create<UserParse>();
            newUser = new UserParse
            {
                Username = username,
                Password = password
            };

            await newUser.SignUpAsync();
            if (newUser.IsNew)
            {
                //newUser.SaveAsync();
                await ParseUser.LogInAsync(username, password);
                var newBudget = ParseObject.Create<BudgetParse>();
                newBudget = new BudgetParse
                {
                    Overall = 0.00,
                    HouseholdExpectancy = 0.00,
                    LifestyleExpectancy = 0.00,
                    UnexpectedExpectancy = 0.00,
                    Saved = 0.00,
                };

                await newBudget.SaveAsync();
                newUser.AddToList("Budget", newBudget);
                await newUser.SaveAsync();
            }
        }
    }
}

namespace PersonalAccounter.ViewModels
{
    using System.Linq;
    using Parse;
    using Models;
    using Models.Parse;
    using Models.SQLite.Repository;

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

                var userFromParseCom = ParseObject.GetQuery("User");
                var result = await userFromParseCom.FindAsync();
                var normalResult = result.ToList();
                normalResult.Add(newBudget);

                newBudget = new BudgetParse
                {
                    Overall = 0.00,
                    HouseholdExpectancy = 0.00,
                    LifestyleExpectancy = 0.00,
                    UnexpectedExpectancy = 0.00,
                    Saved = 0.00,
                };
                newBudget.Add("UserId", newUser);
                await newBudget.SaveAsync();
                
                //newUser.AddToList("Budget", newBudget);
                //await newUser.SaveAsync();
            }
        }
    }
}

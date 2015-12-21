namespace PersonalAccounter.Helpers.ViewModelHelpers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Parse;
    using Models;
    using Models.Parse;
    using Models.Repository;
    using Models.SQLite.Repository;
    using System;
    using Windows.UI.Popups;

    public class UserViewModelHelper
    {
        private IRepository<User> users;

        public UserViewModelHelper()
        {
            this.users = GenericRepostory<User>.Repostory;
        }

        public async void SignUpLocally(string username, string password)
        {
            var newUser = new User
            {
                Username = username,
                Password = password
            };

            var userCollection = await this.users.Get();
            if (!userCollection.Contains(newUser))
            {
                await this.users.Insert(newUser);
            }
        }

        public async void SignUpParse(string username, string password)
        {
            var user = ParseUser.Create<UserParse>();
            user = new UserParse
            {
                Username = username,
                Password = password
            };

            if (user.IsDirty)
            {
                await user.SignUpAsync();
                await user.SaveAsync();
            }
            else
            {
                await ParseUser.LogInAsync(username, password);
                //var successMessage = new MessageDialog("You already have a profile. Please, use the sign in form!");
                //await successMessage.ShowAsync();
            }
        }

        public async void SignInUsingParse(string username, string password)
        {
            var coll = await this.users.Get();

            if (coll.Contains(new User {Username = username, Password = password}))
            {
                await ParseUser.LogInAsync(username, password);
                var successMessage = new MessageDialog("You successfully signed in!");
                await successMessage.ShowAsync();
            }
            else
            {
                await this.users.Insert(new User {Username = username, Password = password});
                var user = ParseUser.Create<UserParse>();
                user = new UserParse
                {
                    Username = username,
                    Password = password
                };

                await user.SignUpAsync();
            }
        }
        public async Task<List<User>> Get()
        {
            return await this.users.Get();
        }

        public async Task<User> GetUserById(int id)
        {
            return await users.Get(id);
        }

        public void SignOutUsingParse()
        {
                ParseUser.LogOut();
        }

    }
}

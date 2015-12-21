using System;
using Windows.Foundation.Diagnostics;
using Windows.UI.Popups;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace PersonalAccounter.Helpers.ViewModelHelpers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Parse;
    using Models;
    using Models.Parse;
    using Models.Repository;
    using Models.SQLite.Repository;

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

            if (user.IsNew)
            {
                await user.SignUpAsync();
                await user.SaveAsync();
            }
            else
            {
                var successMessage = new MessageDialog("You already have a profile. Please, use the sign in form!");
                await successMessage.ShowAsync();
            }
        }

        public async void SignInUsingParse(string username, string password)
        {
            await ParseUser.LogInAsync(username, password);
            var successMessage = new MessageDialog("You successfully signed in!");
            await successMessage.ShowAsync();
        }
        public async Task<List<User>> Get()
        {
            return await this.users.Get();
        }

        public async Task<User> GetUserById(int id)
        {
            return await users.Get(id);
        }

    }
}

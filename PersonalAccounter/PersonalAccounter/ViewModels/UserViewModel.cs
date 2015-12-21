using System;
using Windows.UI.Popups;

namespace PersonalAccounter.ViewModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Helpers.ViewModelHelpers;
    using Models;

    public class UserViewModel
    {
        private UserViewModelHelper users;

        public UserViewModel()
        {
            this.users = new UserViewModelHelper();

        }

        public async void Register(string username,string password)
        {
            this.users.SignUpLocally(username, password);
           this.users.SignUpParse(username, password);
            var successMessage = new MessageDialog("You successfully signed up! Please, fill your expected budget!");
            await successMessage.ShowAsync();
        }

        public async void SignIn(string username, string password)
        {
            this.users.SignInUsingParse(username, password);
        }

        public async Task<List<User>> GetUsers()
        {
           return await this.users.Get();
        }
    }
}

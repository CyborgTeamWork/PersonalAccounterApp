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
            //this.users = GenericRepostory<User>.Repostory;
            this.users = new UserViewModelHelper();

        }

        public async void Register(string username,string password)
        {
            users.RegisterUser(username, password);
        }

        public async Task<List<User>> GetUsers()
        {
           return await this.users.Get();
        }
    }
}

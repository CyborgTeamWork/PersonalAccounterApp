using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parse;
using PersonalAccounter.Models;
using PersonalAccounter.Models.Repository;
using SQLite.Net.Platform.WinRT;

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

        public void RegisterUser(string username,string password)
        {
            var newUser = new ParseUser
            {
                Username = username,
                Password = password
            };
            newUser.SignUpAsync();
            
            if (newUser.IsNew)
            {
                newUser.SaveAsync();
            }
        }
    }
}

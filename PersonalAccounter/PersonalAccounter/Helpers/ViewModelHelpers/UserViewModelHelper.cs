namespace PersonalAccounter.Helpers.ViewModelHelpers
{
    using System;
    using System.Collections.Generic;
    using System.Net.NetworkInformation;
    using System.Threading.Tasks;
    using Windows.Networking.Connectivity;
    using Windows.UI.Popups;
    using Parse;
    using Models;
    using Models.Parse;
    using Models.Repository;
    using Models.SQLite.Repository;

    public class UserViewModelHelper
    {
        private IRepository<User> users;
        private BudgetViewModelHelpers budget;

        public UserViewModelHelper()
        {
            this.users = GenericRepostory<User>.Repostory;
            this.budget = new BudgetViewModelHelpers();
        }

        public async void RegisterUser(string username, string password)
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
                this.budget.CreateNewBudget(newUser);
            }

            if (await this.IsConnectedToInternet())
            {
                var user = ParseUser.Create<UserParse>();
                user = new UserParse
                {
                    Username = username,
                    Password = password
                };

                await user.SignUpAsync();
                if (user.IsNew)
                {
                    await ParseUser.LogInAsync(username, password);
                    this.budget.CreateNewBudgetInParse(user);
                    await user.SaveAsync();
                }
            }

        }

        public async Task<List<User>> Get()
        {
            return await this.users.Get();
        }

        public async Task<bool> IsConnectedToInternet()
        {
            bool isConnected = NetworkInterface.GetIsNetworkAvailable();
            if (!isConnected)
            {
                await
                    new MessageDialog(
                        "No internet connection is avaliable. The full functionality of the app isn't avaliable.")
                        .ShowAsync();
            }
            else
            {
                ConnectionProfile InternetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                NetworkConnectivityLevel connection = InternetConnectionProfile.GetNetworkConnectivityLevel();
                if (connection == NetworkConnectivityLevel.None || connection == NetworkConnectivityLevel.LocalAccess)
                {
                    isConnected = false;
                }
            }

            return isConnected;
        }
    }
}

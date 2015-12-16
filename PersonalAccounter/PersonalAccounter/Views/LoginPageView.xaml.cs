<<<<<<< HEAD
﻿using System;
using System.IO;
using Windows.Storage;
using Windows.UI.Notifications;
=======
﻿using PersonalAccounter.ViewModels;
>>>>>>> e07c8ddb4d731ddbe6179e55a6dffdbf6d87d540
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
<<<<<<< HEAD
using PersonalAccounter.Models;
using PersonalAccounter.Models.Repository;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using WinRTXamlToolkit.Controls.Extensions;
=======
>>>>>>> e07c8ddb4d731ddbe6179e55a6dffdbf6d87d540

namespace PersonalAccounter.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPageView : Page
    {
        private IRepository<User> users;

        public LoginPageView()
        {
            this.InitializeComponent();
<<<<<<< HEAD
            this.users = GenericRepostory<User>.Repostory;
=======

            this.DataContext = new UserViewModel("pesho@abv.bg", "password");
        }

        private void Button_Login(object sender, RoutedEventArgs e)
        {
>>>>>>> e07c8ddb4d731ddbe6179e55a6dffdbf6d87d540
        }

        private void Button_Toggle_Click_Login(object sender, RoutedEventArgs e)
        {
            if (!logincontrol1.IsOpen)
            {
                parent.IsEnabled = false;
                this.Opacity = .4;
                container.IsEnabled = true;
                logincontrol1.IsOpen = true;
                pop.Width = Window.Current.Bounds.Width;
            }
            else
            {
                logincontrol1.IsOpen = false;
                this.Opacity = 1.0;
                parent.IsEnabled = true;
            }
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            string username = id.Text;
            string password = pwd.Password;
            var newUser = new User
            {
                WindowsId = username,
                Password = password
            };
            var registered = users.Get().Result;
            if(!registered.Contains(newUser))
            {
                users.Insert(newUser);
                
            }
        }
    }
}

﻿using System;
using System.IO;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using PersonalAccounter.Models;
using PersonalAccounter.Models.Repository;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
using WinRTXamlToolkit.Controls.Extensions;

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
            this.users = GenericRepostory<User>.Repostory;
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
            this.RegisterUser();
            this.Frame.Navigate(typeof(DrillInPage));
        }

        private async void RegisterUser()
        {
            string username = id.Text;
            string password = pwd.Password;
            var newUser = new User
            {
                WindowsId = username,
                Password = password
            };
            var registered =  await users.Get();
            if (!registered.Contains(newUser))
            {
                await users.Insert(newUser);
            }
        }
    }
}

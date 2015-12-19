﻿namespace PersonalAccounter.Views
{
    using System.Collections.Generic;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using PersonalAccounter.ViewModels;
    using PersonalAccounter.ViewModels.PersonalAccounter.ViewModels;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LifeStylePage : Page
    {
        public LifeStylePage()
        {
            this.InitializeComponent();
            var contentViewModel = new LifestyleContentViewModel();

            contentViewModel.LifeStyleExpenses = new List<LifestyleViewModel>()
            {
                new LifestyleViewModel("HOuse Starwars Premiere", "http://i.dailymail.co.uk/i/pix/2008/12/12/article-1094102-02C8957A000005DC-866_468x435.jpg", 40, "The Force is awakening"),
                new LifestyleViewModel("House Friday Night", "http://www.preapps.com/blog/wp-content/uploads/2015/11/tumblr_static_party-music-hd-wallpaper-1920x1200-38501.jpg", 100, "TIME TO PARTYYYY"),
                new LifestyleViewModel("HOuse Monthly Ciggaretes", "http://www.positivechoices.com/sites/www.positivechoices.com/files/images/cigarette%20pack.jpeg", 150, "Bad Bad bad!")
            };

            this.DataContext = new MainPageViewModel(contentViewModel);
            //this.DataContext = new LifestyleContentViewModel();
        }

        private void AddItemClick(object sender, RoutedEventArgs e)
        {
            if (!AddItemPopUp.IsOpen)
            {
                PopUpParent.IsEnabled = false;
                this.Opacity = .4;
                container.IsEnabled = true;
                AddItemPopUp.IsOpen = true;
                AddItemPopUpStack.Width = Window.Current.Bounds.Width;
            }
            else
            {
                AddItemPopUp.IsOpen = false;
                this.Opacity = 1.0;
                PopUpParent.IsEnabled = true;
            }
        }

        public void DeleteConfirmation_Click(object sender, RoutedEventArgs e)
        {
            // some real delete action to be added 
        }
    }
}

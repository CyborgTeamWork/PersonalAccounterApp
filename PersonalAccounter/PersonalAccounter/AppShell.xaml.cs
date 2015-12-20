namespace PersonalAccounter
{
    using System.Collections.Generic;
    using System.Linq;
    using Windows.Foundation;
    using Windows.UI.Xaml.Automation;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Navigation;
    using PersonalAccounter.Controls;
    using PersonalAccounter.Views;

    /// <summary>
    /// The "chrome" layer of the app that provides top-level navigation with
    /// proper keyboarding navigation.
    /// </summary>
    public sealed partial class AppShell : Page
    {
        // Declare the top level nav items
        private List<NavMenuItem> navlist = new List<NavMenuItem>(
            new[]
            {
                new NavMenuItem()
                {
                    Symbol = Symbol.Go,
                    Label = "Sign In",
                    DestPage = typeof(LoginPageView)
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.Contact,
                    Label = "My Expenses",
                    DestPage = typeof(ExpensePage)
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.ThreeBars,
                    Label = "My Budget",
                    DestPage = typeof(BudgetDisplayPage)
                },
                new NavMenuItem()
                {
                    Symbol = Symbol.Edit,
                    Label = "Settings",
                    DestPage = typeof(CommandBarPage)
                },
            });

        public static AppShell Current = null;

        public AppShell()
        {
            this.InitializeComponent();
            this.Loaded += (sender, args) =>
            {
                Current = this;

                this.TogglePaneButton.Focus(FocusState.Programmatic);
            };

            //this.RootSplitView.RegisterPropertyChangedCallback(
            //    SplitView.DisplayModeProperty,
            //    (s, a) =>
            //    {
            //        this.CheckTogglePaneButtonSizeChanged();
            //    });

            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManager_BackRequested;

            NavMenuList.ItemsSource = navlist;
            //this.InitAsync();
        }

        public void SplitView_ManipulationStarted(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            int a = 4;
        }
        public void SplitView_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
                var b = e.Cumulative;
                var bb = b.Translation;
                var x = bb.X;
                var currentpoint = e.Position.X;
            int a = 6;
            //if (currentpoint.X - initialpoint.X >= 500)
            //    //500 is the threshold value, where you want to trigger the swipe right event
            //{
            //    System.Diagnostics.Debug.WriteLine("Swipe Right");
            //    e.Complete();
            //}
        }

        //private void ManipulationsComplete(object sender, ManipulationCompletedRoutedEventArgs e)
        //{
        //}

        public Frame AppFrame { get { return this.frame; } }

        private void AppShell_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            FocusNavigationDirection direction = FocusNavigationDirection.None;
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Left:
                case Windows.System.VirtualKey.GamepadDPadLeft:
                case Windows.System.VirtualKey.GamepadLeftThumbstickLeft:
                case Windows.System.VirtualKey.NavigationLeft:
                    direction = FocusNavigationDirection.Left;
                    break;
                case Windows.System.VirtualKey.Right:
                case Windows.System.VirtualKey.GamepadDPadRight:
                case Windows.System.VirtualKey.GamepadLeftThumbstickRight:
                case Windows.System.VirtualKey.NavigationRight:
                    direction = FocusNavigationDirection.Right;
                    break;

                case Windows.System.VirtualKey.Up:
                case Windows.System.VirtualKey.GamepadDPadUp:
                case Windows.System.VirtualKey.GamepadLeftThumbstickUp:
                case Windows.System.VirtualKey.NavigationUp:
                    direction = FocusNavigationDirection.Up;
                    break;

                case Windows.System.VirtualKey.Down:
                case Windows.System.VirtualKey.GamepadDPadDown:
                case Windows.System.VirtualKey.GamepadLeftThumbstickDown:
                case Windows.System.VirtualKey.NavigationDown:
                    direction = FocusNavigationDirection.Down;
                    break;
            }

            if (direction != FocusNavigationDirection.None)
            {
                var control = FocusManager.FindNextFocusableElement(direction) as Control;
                if (control != null)
                {
                    control.Focus(FocusState.Programmatic);
                    e.Handled = true;
                }
            }
        }

        #region BackRequested Handlers

        private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!e.Handled && this.AppFrame.CanGoBack)
            {
                e.Handled = true;
                this.AppFrame.GoBack();
            }
        }

        #endregion

        #region Navigation
        private void NavMenuList_ItemInvoked(object sender, ListViewItem listViewItem)
        {
            var item = (NavMenuItem)((NavMenuListView)sender).ItemFromContainer(listViewItem);

            if (item != null)
            {
                if (item.DestPage != null &&
                    item.DestPage != this.AppFrame.CurrentSourcePageType)
                {
                    this.AppFrame.Navigate(item.DestPage, item.Arguments);
                }
            }
        }

        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                var item = (from p in this.navlist where p.DestPage == e.SourcePageType select p).SingleOrDefault();
                if (item == null && this.AppFrame.BackStackDepth > 0)
                {
                    // In cases where a page drills into sub-pages then we'll highlight the most recent
                    // navigation menu item that appears in the BackStack
                    foreach (var entry in this.AppFrame.BackStack.Reverse())
                    {
                        item = (from p in this.navlist where p.DestPage == entry.SourcePageType select p).SingleOrDefault();
                        if (item != null)
                            break;
                    }
                }

                var container = (ListViewItem)NavMenuList.ContainerFromItem(item);
                if (container != null)
                {
                    container.IsTabStop = false;
                }
                NavMenuList.SetSelectedItem(container);
                if (container != null)
                {
                    container.IsTabStop = true;
                }
            }
        }

        private void OnNavigatedToPage(object sender, NavigationEventArgs e)
        {
            // After a successful navigation set keyboard focus to the loaded page
            if (e.Content is Page && e.Content != null)
            {
                var control = (Page)e.Content;
                control.Loaded += Page_Loaded;
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ((Page)sender).Focus(FocusState.Programmatic);
            ((Page)sender).Loaded -= Page_Loaded;
           // this.CheckTogglePaneButtonSizeChanged();
        }

        #endregion

        public Rect TogglePaneButtonRect {get; private set;}

        private void TogglePaneButton_Checked(object sender, RoutedEventArgs e)
        {
            RootSplitView.IsPaneOpen = !RootSplitView.IsPaneOpen;
        }
 
        private void NavMenuItemContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
        {
            if (!args.InRecycleQueue && args.Item != null && args.Item is NavMenuItem)
            {
                args.ItemContainer.SetValue(AutomationProperties.NameProperty, ((NavMenuItem)args.Item).Label);
            }
            else
            {
                args.ItemContainer.ClearValue(AutomationProperties.NameProperty);
            }
        }

        public void OpenSignInClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof (LoginPageView));
        }

        private void UIElement_OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            if (e.Velocities.Linear.X < 0)
            {
                RootSplitView.IsPaneOpen = false;
            }
            if (e.Velocities.Linear.X > 0)
            {
                RootSplitView.IsPaneOpen = true;
            }
        }
    }
}

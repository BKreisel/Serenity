using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Animation;
using System;
using System.Collections.Generic;
using Serenity.Views;
using System.Linq;

namespace Serenity
{

    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }
        
        /// <summary>
        /// List of navigatable pages with a tag for binding.
        /// </summary>
        private readonly List<(string Tag, Type Page)> pages = new()
        {
            ("GeneralSettings", typeof(GeneralSettingsView)),
        };

        private void MainNav_Loaded(object sender, RoutedEventArgs e)
        {
            MainNav.SelectedItem = MainNav.MenuItems[0];
            MainNav_Navigate("GeneralSettings", new EntranceNavigationTransitionInfo());
        }

        private void MainNav_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type page = pages.FirstOrDefault(p => p.Tag.Equals(navItemTag)).Page;
            var currentPageType = ContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (page is not null && !Type.Equals(currentPageType, page))
            {
                ContentFrame.Navigate(page, null, transitionInfo);
            }
        }
    }
}

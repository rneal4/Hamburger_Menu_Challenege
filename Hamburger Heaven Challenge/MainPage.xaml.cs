using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hamburger_Heaven_Challenge
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            NavFrame.Navigate(typeof(Financial));
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavFrame.CanGoBack)
                NavFrame.GoBack();
        }

        private void MenuBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = false;

            switch (MenuBar.SelectedItem)
            {
                case ListBoxItem lbi when lbi.Name == HomeMenuItem.Name:
                    NavFrame.Navigate(typeof(Financial));
                    break;
                case ListBoxItem lbi when lbi.Name == FavoritesMenuItem.Name:
                    NavFrame.Navigate(typeof(Food));
                    break;
            }
        } 

        private void NavFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (NavFrame.CurrentSourcePageType == typeof(Food))
                BackButton.Visibility = Visibility.Visible;
            else
                BackButton.Visibility = Visibility.Collapsed;

            switch (NavFrame.Content)
            {
                case Page p when p.GetType() == typeof(Food):
                    PageTitleTextBlock.Text = "Food";
                    break;
                case Page p when p.GetType() == typeof(Financial):
                    PageTitleTextBlock.Text = "Financial";
                    break;
            }
        }
    }
}

using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyFoodApp.Models;
using MyFoodApp.Services.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyFoodApp.Views
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SplitViewShell : Page
    {
        public SplitViewShell()
        {
            InitializeComponent();
            Navigation.Frame = SplitViewFrame;
            Navigation.Navigate(typeof(SearchPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;
            HamburgerButtonGlyph.Fill = MainSplitView.IsPaneOpen
                ? Application.Current.Resources["MenuItemForegroundBrush"] as SolidColorBrush
                : Application.Current.Resources["ApplicationForegroundBrush"] as SolidColorBrush;
        }

        private void SplitViewFrame_OnNavigated(object sender, NavigationEventArgs e)
        {
            var currentSelectedItem =
                Menu.Items.FirstOrDefault(i => (i as MenuItem).NavigationDestination == e.SourcePageType);
            if (currentSelectedItem != null)
            {
                Menu.SelectedItem = currentSelectedItem;
                return;
            }

            Menu.SelectedIndex = -1;

            currentSelectedItem =
                SecondMenu.Items.FirstOrDefault(i => (i as MenuItem).NavigationDestination == e.SourcePageType);
            if (currentSelectedItem != null)
            {
                SecondMenu.SelectedItem = currentSelectedItem;
                return;
            }

            SecondMenu.SelectedIndex = -1;
        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var listView = sender as ListView;
                if (listView != null && listView.Equals(Menu))
                    SecondMenu.SelectedItem = null;
                else
                    Menu.SelectedItem = null;

                var menuItem = e.AddedItems.First() as MenuItem;
                if (menuItem != null && menuItem.HasNavigationDestination)
                    Navigation.Navigate(menuItem.NavigationDestination);
            }
        }

        private void MainSplitViewPaneGrid_OnManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
        }

        private void MainSplitView_OnPaneClosing(SplitView sender, SplitViewPaneClosingEventArgs args)
        {
            HamburgerButtonGlyph.Fill = Application.Current.Resources["ApplicationForegroundBrush"] as SolidColorBrush;
        }
    }
}
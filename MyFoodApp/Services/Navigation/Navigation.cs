using System;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace MyFoodApp.Services.Navigation
{
    public static class Navigation
    {
        private static EventHandler<BackRequestedEventArgs> BackEventHandler => (sender, args) => GoBack();

        public static Frame Frame { get; set; }


        public static void EnableBackButton()
        {
            var navigationManager = SystemNavigationManager.GetForCurrentView();
            navigationManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            navigationManager.BackRequested -= BackEventHandler;
            navigationManager.BackRequested += BackEventHandler;
        }

        public static void DisableBackButton()
        {
            if (SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility ==
                AppViewBackButtonVisibility.Visible)
            {
                var navManager = SystemNavigationManager.GetForCurrentView();
                navManager.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
                navManager.BackRequested -= BackEventHandler;
                navManager.BackRequested += BackEventHandler;
                navManager.BackRequested -= BackEventHandler;
            }
        }


        public static void GoBack()
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        public static bool Navigate(Type sourcePageType, object  e)
        {
            if (Frame.CurrentSourcePageType != sourcePageType)
                return Frame.Navigate(sourcePageType, e);
            return true;
        }

        public static bool Navigate(Type sourcePageType)
        {
            if (Frame.CurrentSourcePageType != sourcePageType)
                return Frame.Navigate(sourcePageType);
            return true;
        }
    }
}
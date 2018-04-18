using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace MyFoodApp.Services.Themes
{
    public static class Theme
    {
        public static void ApplyOnWindowsContainer()
        {
            //Device check

            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var windowsbar = ApplicationView.GetForCurrentView().TitleBar;

                windowsbar.BackgroundColor =
                    (Application.Current.Resources["WindowsbarBackgroundBrush"] as SolidColorBrush)?.Color;

                windowsbar.ButtonBackgroundColor =
                    (Application.Current.Resources["WindowsbarButtonBackgroundBrush"] as SolidColorBrush)?.Color;

                windowsbar.ButtonForegroundColor =
                    (Application.Current.Resources["WindowsbarForegroundBrush"] as SolidColorBrush)?.Color;

                windowsbar.ForegroundColor =
                    (Application.Current.Resources["WindowsbarForegroundBrush"] as SolidColorBrush)?.Color;

                windowsbar.ButtonBackgroundColor =
                    (Application.Current.Resources["WindowsbarButtonBackgroundBrush"] as SolidColorBrush)?.Color;

                windowsbar.ButtonHoverBackgroundColor =
                    (Application.Current.Resources["WindowsbarButtonHoverBrush"] as SolidColorBrush)?.Color;

                windowsbar.ButtonPressedBackgroundColor =
                    (Application.Current.Resources["WindowsbarButtonPressedBrush"] as SolidColorBrush)?.Color;

                windowsbar.ButtonPressedForegroundColor =
                    (Application.Current.Resources["WindowsbarForegroundBrush"] as SolidColorBrush)?.Color;

                windowsbar.ButtonInactiveBackgroundColor =
                    (Application.Current.Resources["WindowsbarBackgroundBrush"] as SolidColorBrush)?.Color;

                windowsbar.ButtonInactiveForegroundColor =
                    (Application.Current.Resources["WindowsbarForegroundBrush"] as SolidColorBrush)?.Color;

                windowsbar.ButtonHoverForegroundColor =
                    (Application.Current.Resources["WindowsbarForegroundBrush"] as SolidColorBrush)?.Color;
            }
        }
    }
}
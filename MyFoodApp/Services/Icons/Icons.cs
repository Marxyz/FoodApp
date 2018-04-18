using Windows.UI.Xaml;

namespace MyFoodApp.Services.Icons
{
    public static class Icons
    {
        public static string GetIcon(string name)
        {
            return Application.Current.Resources[name] as string;
        }
    }
}
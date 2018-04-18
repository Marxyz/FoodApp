using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MyFoodApp.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyFoodApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        public FoodItemViewModel ItemViewModel = new FoodItemViewModel();

        public DetailPage()
        {
            this.InitializeComponent();
            
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                var foodModel =  e.Parameter as FoodItemViewModel;
                ItemViewModel = foodModel;    
            }   
        }  
    }

    public class StringArrayToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string result = null;
            if (value == null) return null;
            if (!(value is string[] stringArray)) return null;
            for (int i = 0; i < stringArray.Length; i++)
            {
                result += $"{i}. {stringArray[i]}{Environment.NewLine}";
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

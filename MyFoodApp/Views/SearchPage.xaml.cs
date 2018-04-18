using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MyFoodApp.Models;
using MyFoodApp.Services.ApiConfig;
using MyFoodApp.Services.ApiToFoodFactory;
using MyFoodApp.Services.Navigation;
using MyFoodApp.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyFoodApp
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        private readonly ApiClient _apiClient;
        private readonly QueryConfiguration _qConfiguration;
        private readonly FoodItemRepository _repository;
        private readonly Random _rng;

        public SearchPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            _rng = new Random(DateTime.Now.Ticks.GetHashCode());
            _repository = new FoodItemRepository(_rng);
            _qConfiguration = new QueryConfiguration();
            _apiClient = new ApiClient();
        }

        private async Task DisplayResultsAsync(FoodData data)
        {
            if (Dispatcher.HasThreadAccess)
            {
                _repository.Clear();
                _repository.ExtractDataToRepository(data);
            }
            else
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Low, async () => await DisplayResultsAsync(data));
            }
        }


        private async Task TranslateAndAddResultsToViewAsync(string result)
        {
            await Task.Run(() => TranslateAndAddResultsToView(result));
        }

        private async void TranslateAndAddResultsToView(string result)
        {
            var foodData = FoodData.FromJson(result);

            await DisplayResultsAsync(foodData);
        }

        private async void AutoSuggestBox_OnQuerySubmitted(AutoSuggestBox sender,
            AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            try
            {
                ProgressRing.Visibility = Visibility.Visible;
                ProgressRing.IsActive = true;
                var result = await _apiClient.MakeRequestAsync(args.QueryText, _qConfiguration);
                await TranslateAndAddResultsToViewAsync(result);
                ProgressRing.IsActive = false;
                ProgressRing.Visibility = Visibility.Collapsed;
            }
            catch (Exception e)
            {
                ProgressRing.IsActive = false;
                ProgressRing.Visibility = Visibility.Collapsed;
                var dialog = new MessageDialog(e.Message);
                await dialog.ShowAsync();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void SearchGridView_OnItemClick(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            
            if (selectionChangedEventArgs.AddedItems.Count != 0)
            {
                var foodItem = selectionChangedEventArgs.AddedItems.First() as FoodItemViewModel;
                Navigation.EnableBackButton();
                Navigation.Navigate(typeof(DetailPage), foodItem);
            }
        }
    }
}
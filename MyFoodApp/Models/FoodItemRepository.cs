using System;
using System.Collections.ObjectModel;
using System.Linq;
using MyFoodApp.Services.ApiToFoodFactory;

namespace MyFoodApp.Models
{
    internal class FoodItemRepository : BaseViewModel
    {
        private readonly Random _rng;


        public FoodItemRepository(Random rng)
        {
            FoodItems = new ObservableCollection<FoodItemViewModel>();
            _rng = rng;
        }

        public ObservableCollection<FoodItemViewModel> FoodItems { get; set; }

        public void ExtractDataToRepository(FoodData data)
        {
            data.Hits.ToList().ForEach(e => FoodItems.Add(new FoodItemViewModel(e.RecipeDataModel, _rng)));
            OnPropertyChanged(nameof(FoodItems));
        }

        public void Clear()
        {
            FoodItems.Clear();
            OnPropertyChanged(nameof(FoodItems));
        }
    }
}
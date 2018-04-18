using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MyFoodApp.Services.ApiToFoodFactory;

namespace MyFoodApp.Models
{
    public class FoodItemViewModel : BaseViewModel
    {
        public List<InfoLabel> Labels;
        private Random _rng;
        private RecipeDataModel _recipeModel;

        private void GetAllLabels()
        {
            foreach (var dietLabel in RecipeModel.DietLabels)
            {
                var label = CategoryLabelSorter.StringToDietLabel(dietLabel);
                if (label != null)
                {
                    Labels.Add(new InfoLabel(label.ToString(), _rng));
                }
            }

            foreach (var healthLabel in RecipeModel.HealthLabels)
            {
                var label = CategoryLabelSorter.StringToHealthLabel(healthLabel);
                if (label != null)
                {
                    Labels.Add(new InfoLabel(label.ToString(), _rng));
                }
            }
        }


        public FoodItemViewModel(RecipeDataModel recipeModel, Random rng)
        {
            RecipeModel = recipeModel;
            Labels = new List<InfoLabel>();
            _rng = rng;
            GetAllLabels();
        }

        public FoodItemViewModel()
        {
            
        }

        public double CaloriesPerPortion { get; set; }

        public string IngredientsText
            => string.Join(Environment.NewLine, RecipeModel.IngredientsDataModel.ToList().Select(e => e.Text));

        public double CaloriesPerServing => RecipeModel.Calories / 1.0 * RecipeModel.Yield;

        public RecipeDataModel RecipeModel
        {
            get { return _recipeModel; }
            set { _recipeModel = value; }
        }
    }
}
using System;
using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace MyFoodApp.Models
{
    public class InfoLabel
    {
        private static readonly List<Color> ColourValues = new List<Color>
        {
            Colors.Chartreuse,
            Colors.Aqua,
            Colors.Aquamarine,
            Colors.Coral,
            Colors.DeepPink,
            Colors.DodgerBlue,
            Colors.LightCoral,
            Colors.MediumSpringGreen,
            Colors.Bisque,
            Colors.Gold,
            Colors.Violet,
            Colors.DarkSalmon,
            Colors.HotPink
        };

        public Brush Color;

        public string Text;

        public InfoLabel(string text, Random rng)
        {
            Text = text;
            Color = new SolidColorBrush(ColourValues[rng.Next(ColourValues.Count)]);
        }
    }
}
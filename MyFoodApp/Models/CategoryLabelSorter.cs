using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFoodApp.Models
{
    public static class CategoryLabelSorter
    {
        public static DietCategoryLabel? StringToDietLabel(string text)
        {
            text = text.Replace("-", "").ToLower();
            DietCategoryLabel? returnLabel = null;
            var dietlabels = Enum.GetNames(typeof(DietCategoryLabel));
            foreach (var dietlabel in dietlabels)
            {
                var label = dietlabel.ToLower();
                if (label == text)
                {
                    returnLabel = (DietCategoryLabel)Enum.Parse(typeof(DietCategoryLabel), dietlabel);
                }
            }
            return returnLabel;

        }

        public static HealthCategoryLabel? StringToHealthLabel(string text)
        {
            text = text.Replace("-", "").ToLower();
            HealthCategoryLabel? returnLabel = null;
            var dietlabels = Enum.GetNames(typeof(HealthCategoryLabel));
            foreach (var dietlabel in dietlabels)
            {

                var label = dietlabel.ToLower();
                if (label == text)
                {
                    returnLabel = (HealthCategoryLabel)Enum.Parse(typeof(HealthCategoryLabel), dietlabel);
                }
            }
            return returnLabel;

        }
    }
}

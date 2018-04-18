using MyFoodApp.Models;
using Newtonsoft.Json;

namespace MyFoodApp.Services.ApiToFoodFactory
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var data = FoodData.FromJson(jsonString);
    //
    // For POCOs visit quicktype.io?poco
    //


    public partial class FoodData
    {
        [JsonProperty("more")]
        public bool More { get; set; }

        [JsonProperty("from")]
        public long From { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("hits")]
        public Hit[] Hits { get; set; }

        [JsonProperty("q")]
        public string Q { get; set; }

        [JsonProperty("params")]
        public Params Params { get; set; }

        [JsonProperty("to")]
        public long To { get; set; }
    }

    public class Hit
    {
        [JsonProperty("bought")]
        public bool Bought { get; set; }

        [JsonProperty("bookmarked")]
        public bool Bookmarked { get; set; }

        [JsonProperty("recipe")]
        public RecipeDataModel RecipeDataModel { get; set; }
    }

    public class RecipeDataModel
    {
        [JsonProperty("ingredients")]
        public IngredientDataModel[] IngredientsDataModel { get; set; }


        [JsonProperty("digest")]
        public DigestDataModel[] DigestDataModel { get; set; }

        [JsonProperty("cautions")]
        public object[] Cautions { get; set; }

        [JsonProperty("calories")]
        public double Calories { get; set; }

        [JsonProperty("dietLabels")]
        public string[] DietLabels { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("healthLabels")]
        public string[] HealthLabels { get; set; }

        [JsonProperty("ingredientLines")]
        public string[] IngredientLines { get; set; }

        [JsonProperty("totalDaily")]
        public TotalDataModel TotalDataModelDaily { get; set; }

        [JsonProperty("shareAs")]
        public string ShareAs { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("totalWeight")]
        public double TotalWeight { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("totalNutrients")]
        public TotalDataModel TotalDataModelNutrients { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("yield")]
        public long Yield { get; set; }
    }

    public class IngredientDataModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }
    }

    public class DigestDataModel
    {
        [JsonProperty("schemaOrgTag")]
        public string SchemaOrgTag { get; set; }

        [JsonProperty("hasRDI")]
        public bool HasRDI { get; set; }

        [JsonProperty("daily")]
        public double Daily { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("sub")]
        public DigestDataModel[] Sub { get; set; }

        [JsonProperty("total")]
        public double Total { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public class TotalDataModel
    {
        [JsonProperty("FAT")]
        public CA FAT { get; set; }

        [JsonProperty("NIA")]
        public CA NIA { get; set; }

        [JsonProperty("ENERC_KCAL")]
        public CA ENERCKCAL { get; set; }

        [JsonProperty("CHOCDF")]
        public CA CHOCDF { get; set; }

        [JsonProperty("CA")]
        public CA CA { get; set; }

        [JsonProperty("CHOLE")]
        public CA CHOLE { get; set; }

        [JsonProperty("FAPU")]
        public CA FAPU { get; set; }

        [JsonProperty("FAMS")]
        public CA FAMS { get; set; }

        [JsonProperty("FASAT")]
        public CA FASAT { get; set; }

        [JsonProperty("FOLDFE")]
        public CA FOLDFE { get; set; }

        [JsonProperty("FE")]
        public CA FE { get; set; }

        [JsonProperty("FATRN")]
        public CA FATRN { get; set; }

        [JsonProperty("FIBTG")]
        public CA FIBTG { get; set; }

        [JsonProperty("MG")]
        public CA MG { get; set; }

        [JsonProperty("K")]
        public CA K { get; set; }

        [JsonProperty("NA")]
        public CA NA { get; set; }

        [JsonProperty("SUGAR")]
        public CA SUGAR { get; set; }

        [JsonProperty("VITB12")]
        public CA VITB12 { get; set; }

        [JsonProperty("PROCNT")]
        public CA PROCNT { get; set; }

        [JsonProperty("P")]
        public CA P { get; set; }

        [JsonProperty("RIBF")]
        public CA RIBF { get; set; }

        [JsonProperty("TOCPHA")]
        public CA TOCPHA { get; set; }

        [JsonProperty("THIA")]
        public CA THIA { get; set; }

        [JsonProperty("VITA_RAE")]
        public CA VITARAE { get; set; }

        [JsonProperty("VITC")]
        public CA VITC { get; set; }

        [JsonProperty("VITK1")]
        public CA VITK1 { get; set; }

        [JsonProperty("VITB6A")]
        public CA VITB6A { get; set; }

        [JsonProperty("VITD")]
        public CA VITD { get; set; }

        [JsonProperty("ZN")]
        public CA ZN { get; set; }
    }

    public class CA
    {
        [JsonProperty("quantity")]
        public double Quantity { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }

    public class Params
    {
        [JsonProperty("app_key")]
        public string[] AppKey { get; set; }

        [JsonProperty("q")]
        public string[] Q { get; set; }

        [JsonProperty("app_id")]
        public string[] AppId { get; set; }

        [JsonProperty("from")]
        public string[] From { get; set; }

        [JsonProperty("sane")]
        public object[] Sane { get; set; }

        [JsonProperty("to")]
        public string[] To { get; set; }
    }


    public partial class FoodData
    {
        public static FoodData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FoodData>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this FoodData self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };
    }
}
namespace MyFoodApp.Services.ApiConfig
{
    internal class QueryConfiguration
    {
        public QueryConfiguration()
        {
            CaloriesFromIndex = null;
            CaloriesToIndex = null;
            FromIndex = 0;
            ToIndex = FromIndex + 10;
        }

        public int FromIndex { get; set; }
        public int ToIndex { get; set; }

        public int? CaloriesFromIndex { get; set; }
        public int? CaloriesToIndex { get; set; }


        //search?q=chicken&app_id=${YOUR_APP_ID}&app_key=${YOUR_APP_KEY}&from=0&to=3&calories=gte%20591,%20lte%20722&health=alcohol-free"

        public string GetStringIntepretation()
        {
            var result = $"&from={FromIndex}&to={ToIndex}";

            if (CaloriesFromIndex == null && CaloriesToIndex != null)
                result += $"&calories=lte {CaloriesToIndex}";
            if (CaloriesToIndex == null && CaloriesFromIndex != null)
                result += $"&calories=gte {CaloriesFromIndex}";
            if (CaloriesFromIndex != null && CaloriesToIndex != null)
                result += $"&calories=gte {CaloriesFromIndex}, lte {CaloriesFromIndex}";


            return result;
        }
    }
}
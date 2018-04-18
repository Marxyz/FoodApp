namespace MyFoodApp.Services.ApiConfig
{
    internal class ApiQuery
    {
        private readonly QueryConfiguration _queryConfiguration;
        public readonly string Query;

        public ApiQuery(string query, QueryConfiguration queryConfiguration)
        {
            Query = query;
            _queryConfiguration = queryConfiguration;
            StringQueryDetails = MakeQueryDetails();
            Query = MakeStringInterpretation();
        }

        public string BaseUrl { get; } = "https://api.edamam.com/search?";
        public string StringQueryDetails { get; set; }

        private string MakeQueryDetails()
        {
            return $"q={Query}"
                   + $"&app_id={UserConfiguration.ApplicationId}"
                   + $"&app_key={UserConfiguration.ApplicationKey}"
                   + _queryConfiguration.GetStringIntepretation();
        }

        //search?q=chicken&app_id=${YOUR_APP_ID}&app_key=${YOUR_APP_KEY}&from=0&to=3&calories=gte%20591,%20lte%20722&health=alcohol-free"
        private string MakeStringInterpretation()
        {
            return BaseUrl + MakeQueryDetails();
        }
    }
}
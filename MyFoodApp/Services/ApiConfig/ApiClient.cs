using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyFoodApp.Services.ApiConfig
{
    internal class ApiClient
    {
        public readonly ApiLimitManager ApiLimitManager;

        public ApiClient()
        {
            ApiLimitManager = new ApiLimitManager();
            HttpClient = new HttpClient {BaseAddress = new Uri(BaseUrl)};
        }

        private static string BaseUrl { get; } = "https://api.edamam.com/search?";
        private HttpClient HttpClient { get; }

        public async Task<string> MakeRequestAsync(string query, QueryConfiguration queryConfiguration)
        {
            if (ApiLimitManager.IsQueryAvailable)
            {
                try
                {
                    var apiQuery = new ApiQuery(query, queryConfiguration);
                    var response = await HttpClient.GetAsync("/search?" + apiQuery.StringQueryDetails);
                    var result = await response.Content.ReadAsStringAsync();
                    ApiLimitManager.IncrementQueryCount();
                    return result;
                }
                catch (Exception e)
                {
                    var exc1 = new Exception("Connection Error - check your internet connection.", e);
                    throw exc1;
                    
                }
            }
            var exc =
                new Exception(string.Format("Calls limit exceeded.{0}Wait a couple of seconds and try again.",
                    Environment.NewLine));
            throw exc;
        }
    }
}
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace NasaWeb.Api
{
    public class ApiHelper
    {
        public HttpClient ApiClient { get; set; }

        public  void InitializeClient()
        {
            ApiClient = new HttpClient();

            string baseUrl = "https://api.nasa.gov/neo/rest/v1/neo/browse";

            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.BaseAddress = new Uri(baseUrl);
        }
    }
}

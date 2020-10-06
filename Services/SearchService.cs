using JustEatTechnicalTest.Models;
using System.Net.Http;
using System.Threading.Tasks;
using JustEatTechnicalTest.Services.Interfaces;
using System.Text.Json;
using System;

namespace JustEatTechnicalTest.Services
{
    public class SearchService : ISearchService
    {
        private readonly IHttpClientFactory _clientFactory;
        //private readonly IRequestSetupService _requestSetupService;

        public SearchService(IHttpClientFactory clientFactory /*, IRequestSetupService requestSetupService*/)
        {
            _clientFactory = clientFactory;
            //_requestSetupService = requestSetupService;
        }

        public async Task<Root> GetRestaurantsAsync(string postcode)
        {
            var restaurants = new Root();

            var client = _clientFactory.CreateClient("justeat");

            var response = await client.GetAsync($"/restaurants?q={postcode}");

            //Leave in to show original working
            //var request = _requestSetupService.SetupRequest(postcode);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Root>(responseStream);
            }
            else
            {
                return restaurants;
            }
        }
    }
}

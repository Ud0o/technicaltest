using JustEat.Api.Models;
using System.Net.Http;
using System.Threading.Tasks;
using JustEat.Api.Services.Interfaces;
using System.Text.Json;
using System;

namespace JustEat.Api.Services
{
    public class SearchService : ISearchService
    {
        private readonly IHttpClientFactory _clientFactory;
        private HttpClient _httpClient { get; set; }

        public SearchService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _httpClient = _clientFactory.CreateClient("justeat");
        }

        public SearchService()
        {
        }

        public async Task<JustEatResponse> GetRestaurantsAsync(string postcode)
        {
            var restaurants = new JustEatResponse();

            var response = await _httpClient.GetAsync($"/restaurants?q={postcode}");

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<JustEatResponse>(stream);
            }
            else
            {
                return restaurants;
            }
        }
    }
}

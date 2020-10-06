using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustEatTechnicalTest.Models;
using JustEatTechnicalTest.Services.Interfaces;

namespace JustEatTechnicalTest.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        public IActionResult Index()
        {
            var restaurants = new List<Restaurant>();
            return View(restaurants);
        }

        public async Task<IActionResult> GetRestaurants(string postcode)
        {
            var json = await _searchService.GetRestaurantsAsync(postcode);

            return View("Index", json.Restaurants);
        }
    }
}

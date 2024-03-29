﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using JustEat.Api.Models;
using JustEat.Api.Services.Interfaces;
using System;

namespace JustEat.Api.Controllers
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
            if (string.IsNullOrEmpty(postcode))
            {
                return new BadRequestObjectResult(new { Error = "Postcode required." });
            }
            var response = await _searchService.GetRestaurantsAsync(postcode);
            return View("Index", response.Restaurants);
        }
    }
}

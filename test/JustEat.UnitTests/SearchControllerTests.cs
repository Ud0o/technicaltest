using JustEat.Api.Controllers;
using JustEat.Api.Models;
using JustEat.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace JustEat.UnitTests
{
    public class SearchControllerTests
    {
        [Fact]
        public async void ValidPostcode_GetRestaurants_ReturnsView()
        {
            var mock = new Mock<ISearchService>();
            var dummyResponse = new JustEatResponse()
            {
                Restaurants = new List<Restaurant>()
            };
            mock.Setup(search => search.GetRestaurantsAsync("BS16BN")).ReturnsAsync(dummyResponse);
            var controller = new SearchController(mock.Object);
            var actionResult = await controller.GetRestaurants("BS16BN");

            var viewResult = Assert.IsType<ViewResult>(actionResult);
            var model = Assert.IsAssignableFrom<IEnumerable<Restaurant>>(
                viewResult.ViewData.Model);
        }

        [Fact]
        public async void InvalidPostcode_GetRestaurants_ReturnsBadRequestObject()
        {
            var mock = new Mock<ISearchService>();
            var controller = new SearchController(mock.Object);
            var actionResult = await controller.GetRestaurants(string.Empty);

            var badResult = actionResult as BadRequestObjectResult;
            Assert.NotNull(badResult);
            Assert.Equal(400, badResult.StatusCode);
        }
    }
}

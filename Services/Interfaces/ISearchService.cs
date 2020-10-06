using JustEatTechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustEatTechnicalTest.Services.Interfaces
{
    public interface ISearchService
    {
        Task<Root> GetRestaurantsAsync(string postcode);
    }
}

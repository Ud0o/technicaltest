﻿using JustEat.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustEat.Api.Services.Interfaces
{
    public interface ISearchService
    {
        Task<JustEatResponse> GetRestaurantsAsync(string postcode);
    }
}

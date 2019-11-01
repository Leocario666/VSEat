using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IRestaurantsDB
    {
        IConfiguration Configuration { get; }
        List<Restaurants> GetRestaurants();
        Restaurants GetRestaurant(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using DTO;

namespace DAL
{
    public interface IRestaurantDB
    {
       
        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);
    }
}

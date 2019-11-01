using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;


namespace BLL
{
    public class CitiesManager
    {

        public ICitiesDB CitiesDB { get; }

        public CitiesManager(IConfiguration configuration)
        {
            CitiesDB = new CitiesDB(configuration);
        }

        public List<Cities> GetCities()
        {
            return CitiesDB.GetCities();
        }

        public Cities GetCity(int code)
        {
            return CitiesDB.GetCity(code);
        }
    }
}

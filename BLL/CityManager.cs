using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;


namespace BLL
{
    public class CityManager
    {

        public ICityDB CityDB { get; }

        public CityManager(IConfiguration configuration)
        {
            CityDB = new CityDB(configuration);
        }

        public List<City> GetCities()
        {
            return CityDB.GetCities();
        }

        public City GetCity(int code)
        {
            return CityDB.GetCity(code);
        }
    }
}

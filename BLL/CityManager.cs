using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;


namespace BLL
{
    public class CityManager:ICityManager
    {

        public ICityDB CityDB { get; }

        public CityManager(ICityDB cityDB)
        {
            CityDB = cityDB;
        }

        public List<City> GetCities()
        {
            return CityDB.GetCities();
        }

    }
}

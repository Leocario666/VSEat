using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface ICityManager
    {
        ICityDB CityDB { get; }

        List<City> GetCities();
        City GetCity(int code);
    }
}

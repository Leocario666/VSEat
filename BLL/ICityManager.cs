using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface ICityManager
    {
        // List of the methods we can use 
        List<City> GetCities();
    }
}

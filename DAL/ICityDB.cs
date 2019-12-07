using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface ICityDB
    {
        
        List<City> GetCities();
        City GetCity(int code);

    }
}

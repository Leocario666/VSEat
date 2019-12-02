using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface ICityManager
    {
        ICitiesDB CitiesDB { get; }

        List<Cities> GetCities();
        Cities GetCity(int code);
    }
}

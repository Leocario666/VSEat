using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface IDelivery_staffDB
    {
        // List of the methods we can use 
        bool isUserValid(Delivery_staff ds);
        Delivery_staff GetDelivery_staff(int id);
        List<Delivery_staff> GetDelivery_staffs();
    }
}

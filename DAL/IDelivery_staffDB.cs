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
        Delivery_staff GetDelivery_staff(int id);
    }
}

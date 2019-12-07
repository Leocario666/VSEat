using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDelivery_staffManager
    {
        // List of the methods we can use
        Delivery_staff GetDelivery_staff(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDelivery_staffManager
    {
        string login { get; }

        // List of the methods we can use
        bool isUserValid(Delivery_staff ds);
        Delivery_staff GetDelivery_staff(int id);
        List<Delivery_staff> GetDelivery_staffs();
    }
}

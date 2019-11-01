using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public interface IDelivery_staffManager
    {
        IDelivery_staffDB Delivery_staffDB { get; }

        List<Delivery_staff> GetDelivery_staffs();
        Delivery_staff GetDelivery_staff(int id);
    }
}

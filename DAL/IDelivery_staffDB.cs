using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public interface IDelivery_staffDB
    {
        IConfiguration Configuration { get; }
        List<Delivery_staff> GetDelivery_staffs();
        Delivery_staff GetDelivery_staff(int id);
    }
}

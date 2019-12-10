using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using Microsoft.Extensions.Configuration;
using DTO;


namespace BLL
{
    public class Delivery_staffManager:IDelivery_staffManager
    {

        private IDelivery_staffDB Delivery_staffDB { get; }

        public Delivery_staffManager(IDelivery_staffDB delivery_StaffDB)
        {
            Delivery_staffDB = delivery_StaffDB;
        }

        // ******************************************************************** // 
        // Method which manages the test of the connection
        // ******************************************************************** // 
        public bool isUserValid(Delivery_staff ds)
        {
            return Delivery_staffDB.isUserValid(ds);
        }

        public List<Delivery_staff> GetDelivery_staffs()
        {
            return Delivery_staffDB.GetDelivery_staffs();
        }

        // ******************************************************************** // 
        // Method which manages the display of one delivery staff
        // ******************************************************************** // 
        public Delivery_staff GetDelivery_staff(int id)
        {
            return Delivery_staffDB.GetDelivery_staff(id);
        }
    }
}

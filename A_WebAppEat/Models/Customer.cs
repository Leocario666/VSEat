using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSEat.Models
{
    public class Customer
    {
        public int customer_Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int cityCode { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public override string ToString()
        {
            return $"{first_name.ToString()}|{last_name.ToString()}|{cityCode.ToString()}|{login.ToString()}|{password.ToString()}|{address.ToString()}";
        }
    }
}

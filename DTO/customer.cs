using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    // Object Customer
    public class Customer
    {

        public int customer_Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int cityCode { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string address { get; set; }
    }
   
}

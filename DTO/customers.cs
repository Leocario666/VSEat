using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Customers
    {

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int city_code { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public override string ToString()
        {
            return $"{id}|{first_name}|{last_name}|{city_code}|{login}|{password}";
        }
    }
   
}

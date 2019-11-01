using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Delivery_staff
    {
        public int id { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
        public int city_code { get; set; }
        public String login { get; set; }
        public String password { get; set; }

        public override string ToString()
        {
            return $"{id}|{first_name}|{last_name}|{city_code}|{login}|{password}";
        }
    }
}

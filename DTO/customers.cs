using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class Customers
    {

        protected int id { get; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime created_at { get; }
        public int city_code { get; }
        public string login { get; set; }
        public string password { get; set; }
        public override string ToString()
        {
            return $"{id}|{first_name}|{last_name}|{created_at}|{city_code}|{login}|{password}";
        }
    }
   
}

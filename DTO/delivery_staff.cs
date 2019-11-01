using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class delivery_staff
    {
        public int id { get; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public int city_code { get; }
        public String login { get; set; }
        public String password { get; set; }

        public override string ToString()
        {
            return $"{id}|{firstname}|{lastname}|{city_code}|{login}|{password}";
        }
    }
}

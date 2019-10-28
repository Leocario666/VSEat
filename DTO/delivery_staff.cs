using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class delivery_staff
    {
        public int id { get; }
        public String firstname { get; }
        public String lastname { get; }
        public int city_code { get; }
        public String login { get; }
        public String password { get; }

        public override string ToString()
        {
            return $"{id}|{firstname}|{lastname}|{city_code}|{login}|{password}";
        }
    }
}

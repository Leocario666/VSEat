using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Cities
    {
        public int code { get; set; }
        public String name { get; set; }

        public override string ToString()
        {
            return $"{code}|{name}";
        }

    }
}

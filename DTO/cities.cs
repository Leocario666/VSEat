using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    class cities
    {
        public int code { get;  }
        public String name { get; }

        public override string ToString()
        {
            return $"{code}|{name}";
        }

    }
}

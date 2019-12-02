using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Restaurant
    {
        public int restaurant_Id { get; set; }
        public string name { get; set; }
        public DateTime created_at { get; set; }
        public int cityCode { get; set; }
    }
}

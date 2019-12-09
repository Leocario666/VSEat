using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VSEat.Models
{
    public class DeliveryStaff
    {
        [Required(ErrorMessage ="A login is required")]
        public string login { get; set; }

        [Required(ErrorMessage = "A password is required")]
        public string password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VSEat.Models
{
    public class Customer
    {
        public int customer_Id { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")] // Check to have only letters
        [Required(ErrorMessage = "A first name is resquired")]  // Error message
        [DisplayName("Your first name")]
        public string first_name { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")] // Check to have only letters
        [Required(ErrorMessage = "A last name is resquired")]  // Error message
        [DisplayName("Your last name")]
        public string last_name { get; set; }

        [DisplayName("NPA")]
        public int cityCode { get; set; }


        [Required(ErrorMessage = "A login is resquired")]  // Error message
        public string login { get; set; }

        [Required(ErrorMessage = "A password is resquired")]  // Error message
        public string password { get; set; }

        [Required(ErrorMessage = "An address is resquired")]  // Error message
        public string address { get; set; }

        
    }
}

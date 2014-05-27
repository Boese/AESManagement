using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AESManagement.Models
{
    public class StoreModel
    {
        [DisplayName("Store #")]
        public int StoreId { get; set; }
        [Required(ErrorMessage = "A Store Name is required")]
        [DisplayName("Store Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A Street Address is required")]
        [DisplayName("Street Address")]
        public string Street { get; set; }
        [Required(ErrorMessage = "A City is required")]
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("State")]
        [RegularExpression(@"[a-zA-Z]{2,2}$", ErrorMessage = "A State code of 2 letters is required")]
        public string State { get; set; }
        [DisplayName("Zipcode")]
        [RegularExpression(@"[0-9]{5,5}$", ErrorMessage = "A Zipcode of 5 numbers is required")]
        public string Zip { get; set; }
    }
}
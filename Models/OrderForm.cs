using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Farmerce.Models
{
    public class OrderForm
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "What would you like to buy?")]
        [Required(ErrorMessage = "Required")]
        [DataType(DataType.MultilineText)]
        public string itemBuy { get; set; }

        [Display(Name = "How many would you like to buy?")]
        [Required(ErrorMessage = "Required")]
        public int quantity { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Required")]
        public string fullName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Required")]
        public string emailAddress { get; set; }
        
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Required")]
        public int phoneNumber { get; set; }
    }
}

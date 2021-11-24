using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Farmerce.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Requried field.")]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid format.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Contact Number")]
        [Required(ErrorMessage = "Required field.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Required field.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Required field.")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
        
    }
}

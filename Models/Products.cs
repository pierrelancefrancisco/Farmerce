using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Farmerce.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "This is required")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "This is required.")]
        [Display(Name = "Product Price")]
        public int ProductPrice { get; set; }

        [Required(ErrorMessage = "This is required.")]
        [Display(Name = "Product Measurement, lbs")]
        public decimal ProductMeasurement { get; set; }


        [Required(ErrorMessage = "This is required.")]
        [Display(Name = "Stocks Left")]
        public int StocksLeft { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Required.")]
        public virtual Category Category { get; set; }

        public int? CatID { get; set; }
    }

    public class Category
    {
        [Key]
        public int CatID { get; set; }

        public string CatName { get; set; }

    }
   
}

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

        [Required(ErrorMessage = "This is required")]
        [Display(Name = "Product Category")]
        public ProductCategory Category { get; set; }
    }
    public enum ProductCategory
    {
        Fruits = 1,
        Vegetables = 2,
        Seeds = 3

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Farmerce.Models
{
    public class ProductCategories
    {
        [Key]
        public int CatID { get; set; }

        [Column("ProductCategory")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Farmerce.Models
{
    public class ProductSummary
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductMeasurement { get; set; }
        public string StocksLeft { get; set; }
        public string Category { get; set; }
    }
}

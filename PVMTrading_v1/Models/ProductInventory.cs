using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class ProductInventory
    {
        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }

        public int PhysicalStockAvialability { get; set; }

        public int Reserved { get; set; }

        public int AvailableForSelling { get; set; }
    }
}
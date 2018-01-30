using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class ProductInventory
    {
        public int ProductCategoryId { get; set; }
        public int PhysicalStockAvialability { get; set; }
        public int Reserved { get; set; }
        public int AvailableForSelling { get; set; }
    }
}
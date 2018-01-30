using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;


namespace PVMTrading_v1.ViewModels
{
    public class ProductViewModel
    {
        public IEnumerable<Brand> Brands { get; set; }

        public IEnumerable<Warranty> Warranties { get; set; }
        public List<Branch> Branches { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductCondition> ProductConditions { get; set; }
        public Product Product { get; set; }

        public ProductInclusion ProductInclusion { get; set; }
        public ProductPrice ProductPrice { get; set; }




    }
}


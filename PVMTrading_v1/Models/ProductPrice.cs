using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class ProductPrice
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public int SellingPrice { get; set; }

        public string Remarks { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
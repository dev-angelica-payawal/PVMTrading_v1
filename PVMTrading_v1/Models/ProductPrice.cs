using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class ProductPrice
    {

        public int Id { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Unit Price")]
        public double UnitPrice { get; set; }

        [Required]
        [Display(Name = "Selling Price")]
        public double SellingPrice { get; set; }

        public string Remarks { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
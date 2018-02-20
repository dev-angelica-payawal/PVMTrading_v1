using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class CashTransactionItem
    {

        public int Id { get; set; }

        public CashTransaction CashTransaction { get; set; }
        public string CashTransactionId { get; set; }

        public Product Product { get; set; }
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        public double ProductPrice { get; set; }

/*
        [Display(Name = "Discount Amount")]
        public double DiscountedAmount { get; set; }
*/

        public int Quantity { get; set; }

    }
}
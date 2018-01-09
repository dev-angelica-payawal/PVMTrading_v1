using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class Transactionitem
    {

        public int Id { get; set; }

        public int TransactionId { get; set; }

        public int ProductId { get; set; }

        public int ProductPriceId { get; set; }

        public int DiscountedAmount { get; set; }

        public int Quantity { get; set; }

    }
}
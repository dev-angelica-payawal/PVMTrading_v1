using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class CashTransaction
    {

        public int Id { get; set; }

        public int DiscountedAmount { get; set; }

        public int OriginalTotalAmount { get; set; }

        public DateTime CashTransactionDate { get; set; }

        public int TotalAmount { get; set; }

        public int EmployeeId { get; set; }

        public int CustomerId { get; set; }

        public int IsVoid { get; set; }

        public string Remarks { get; set; }

        public int DeliveryChargedId { get; set; }

    }
}
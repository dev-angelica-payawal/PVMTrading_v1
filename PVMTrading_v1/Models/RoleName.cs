using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class RoleName
    {

        public const string Admin = "SuperUser";
        public const string SalesClerk = "ViewProducts";
        public const string Cashier = "CreateTransactions";
        public const string Customer = "ViewOnly";
        public const string Delivery = "ViewListDelivery";
    }
}
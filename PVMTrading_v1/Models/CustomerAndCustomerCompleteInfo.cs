using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class CustomerAndCustomerCompleteInfo
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<CustomerCompleInfo> CustomerCompleInfo { get; set; }
    }
}
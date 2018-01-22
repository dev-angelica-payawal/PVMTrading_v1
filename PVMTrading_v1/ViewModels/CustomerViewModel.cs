using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;
using PVMTrading_v1.Models.archieved;

namespace PVMTrading_v1.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<CustomerType> CustomerTypes { get; set; }

    }
}
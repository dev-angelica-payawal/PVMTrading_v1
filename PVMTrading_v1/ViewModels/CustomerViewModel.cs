using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PVMTrading_v1.Models;


namespace PVMTrading_v1.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<CustomerType> CustomerTypes { get; set; }
        public IEnumerable<CivilStatus> CivilStatuses { get; set; }
        public IEnumerable<Sex> Sexs { get; set; }
        public CustomerCompleInfo CustomerCompleInfo { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class Productinclusion
    {

        public int Id { get; set; }


        public int ProductId { get; set; }

        public string FreeItem { get; set; }

        public int Quantity { get; set; }

        //  public int CreatedByEmployeeId { get; set; }

        //        public int LastChangeByEmployeeId { get; set; }

    }
}
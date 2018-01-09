using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class TransactionType
    {

        public int Id { get; set; }

        public string Label { get; set; }

        public int Order { get; set; }

        public int Is_Active { get; set; }

    }
}
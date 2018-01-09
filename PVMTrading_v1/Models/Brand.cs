using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class Brand
    {
        public int Id { get; set; }

        public int BrandTypeId { get; set; }

        public string BrandName { get; set; }
    }
}
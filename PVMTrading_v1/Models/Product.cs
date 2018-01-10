using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int SerialNumber { get; set; }

        public string Model { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsReturned { get; set; }

        public double UnitPrice { get; set; }

       



        // public string Manufacturer { get; set; }

        //       public int SupplierId { get; set; }
        //      public int LastChangeByEmployeeId { get; set; }
        //        public int Barcode { get; set; }
        //     public int ServiceCenterId { get; set; }
        //      public int WarrantyId { get; set; }
        // public int CreatedByEmployeeId { get; set; }


        //  public int BrandId { get; set; }
        //    public int ProductCategoryId { get; set; }


    }
}
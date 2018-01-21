using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class Product
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }

        public int SerialNumber { get; set; }


        public string Model { get; set; }

        public DateTime DateCreated { get; set; }


        public bool IsReturned { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal OriginalPrice { get; set; }
        //   public int LastChangeByEmployeeId { get; set; }
        public int Barcode { get; set; }
        //   public int WarrantyId { get; set; }
        //   public int CreatedByEmployeeId { get; set; }

        public Brand Brand { get; set; }
        public int BrandId { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }

        public ProductCondition ProductCondition { get; set; }
        public int ProductConditionId { get; set; }

        public Branch Branch { get; set; }
        public int BranchId { get; set; }

        //public blob Photo { get; set; }
    }
}
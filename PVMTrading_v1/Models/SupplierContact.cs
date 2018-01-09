using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class SupplierContact
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string NameExtension { get; set; }

        public int Mobile { get; set; }

        public int Telephone { get; set; }

        public string Email { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
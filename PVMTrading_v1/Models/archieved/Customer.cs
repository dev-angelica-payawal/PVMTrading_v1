using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using GitSharp;

namespace PVMTrading_v1.Models
{
    public class Customer
    {

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string NameExtension { get; set; }

        public int Mobile { get; set; }

        public int Telephone { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        public int CivilStatusid { get; set; }

        public int Sexid { get; set; }

        public DateTime RegisteredDateCreated { get; set; }

        public string PlaceOfBirth { get; set; }

        public string Nationality { get; set; }

        public int TaxIdentificationNumber { get; set; }

        public int CustomerTypeId { get; set; }

        //     public Blob Photo { get; set; }

    }
}
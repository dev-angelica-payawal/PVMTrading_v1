using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public DateTime DateCreated { get; set; }

        public string PlaceOfBirth { get; set; }

        public string Nationality { get; set; }

        public int TaxidentificationNumber { get; set; }

        public string UnitRoomFloor { get; set; }

        public string BuildingName { get; set; }

        public int LotBlockHouseNumber { get; set; }

        public string Street { get; set; }

        public string SubdivisionVillage { get; set; }

        public string Barangay { get; set; }

        public string CityMunicipality { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }
    }
}
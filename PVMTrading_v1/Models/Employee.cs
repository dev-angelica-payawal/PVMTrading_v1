using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PVMTrading_v1.Models
{
    public class Employee
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

        public int CivilStatudId { get; set; }

        public int SexId { get; set; }

        public DateTime DateHired { get; set; }

        public string PlaceOfBirth { get; set; }

        public string Nationality { get; set; }

        public int TaxIdentificationNUmber { get; set; }

        public int SocialSecuritySystemId { get; set; }

        public int GSISID { get; set; }

        public string InCaseOfEmergencyName { get; set; }

        public int InCaseOfEmergencyContact { get; set; }

        public int UnitRoomFloor { get; set; }

        public string BuildingName { get; set; }

        public int LotBlockHouseNumber { get; set; }

        public string Street { get; set; }

        public string SubdivisionVillage { get; set; }

        public string Baranggay { get; set; }

        public string CityMunicipality { get; set; }

        public string Province { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }

        public string MotherName { get; set; }

        public string FatherName { get; set; }

        public int EmployeeRoleId { get; set; }

    }
}
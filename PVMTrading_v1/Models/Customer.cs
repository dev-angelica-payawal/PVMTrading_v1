using System;
using System.ComponentModel.DataAnnotations;

namespace PVMTrading_v1.Models
{
    public class Customer
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(255)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [StringLength(255)]
        [Display(Name = "Name Extension")]
        public string NameExtension { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public int Mobile { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int? Telephone { get; set; }


        [StringLength(255)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: MM:dd:yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public CivilStatus CivilStatus { get; set; }
        [Display(Name = "Civil Satus")]
        public int? CivilStatusId { get; set; }

        public Sex Sex { get; set; }
        [Display(Name = "Sex")]
        public int Sexid { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Registered Date Created")]
        public DateTime RegisteredDateCreated { get; set; }


        [StringLength(255)]
        [Display(Name = "Place of Birth")]
        public string PlaceOfBirth { get; set; }


        [StringLength(255)]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }

        [Display(Name = "Tax Identification Number")]
        public int? TaxIdentificationNumber { get; set; }

        public CustomerType CustomerType { get; set; }
        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }

        [StringLength(255)]
        [Display(Name = "Lot/House Number/Street")]
        public string LotHouseNumberAndStreet { get; set; }

        [StringLength(255)]
        public string Barangay { get; set; }

        [StringLength(255)]
        [Display(Name = "City/Municipality")]
        public string CityMunicipality { get; set; }

        [StringLength(255)]
        public string Province { get; set; }

        [StringLength(255)]
        public string Country { get; set; }

        [Display(Name = "Zip Code")]
        public int? ZipCode { get; set; }

        //     public Blob Photo { get; set; }
        
    }
}
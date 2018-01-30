﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using GitSharp;
using PVMTrading_v1.Models;

namespace PVMTrading_v1.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [StringLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Name Extension")]
        public string NameExtension { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public int Mobile { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Telephone { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{mm:dd:yyyy}")]
        public DateTime Birthdate { get; set; }
        
        public CivilStatus CivilStatus { get; set; }
        [Required]
        public int CivilStatusId { get; set; }
        public Sex Sex { get; set; }
        [Display(Name = "Sex")]
        public int Sexid { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Registered Date Created")]
        public DateTime RegisteredDateCreated { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Place of Birth")]
        public string PlaceOfBirth { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Nationality")]
        public string Nationality { get; set; }
        [Required]
        [Display(Name = "Tax Identification Number")]
        public int TaxIdentificationNumber { get; set; }
        public CustomerType CustomerType { get; set; }
        public int CustomerTypeId { get; set; }

        //     public Blob Photo { get; set; }

    }
}
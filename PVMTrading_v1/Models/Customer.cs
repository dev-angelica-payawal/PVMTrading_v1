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
       

        public Sex Sex { get; set; }
        [Display(Name = "Sex")]
        public int Sexid { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Registered Date Created")]
        public DateTime RegisteredDateCreated { get; set; }

        

    }
}
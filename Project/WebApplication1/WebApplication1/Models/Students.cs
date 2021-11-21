using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Students
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        public string RegistrationNo { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        [Display(Name = "Email")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Address")]
        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Display(Name = "Mobile")]
        [Required]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string Mobile { get; set; }

        [Display(Name = "Department")]
        [Required]
        public string DepID { get; set; }


        [Display(Name = "Subject")]
        [Required]
        public string SubID { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only numeric value allowed.")]
        public int Semester { get; set; }


        [Required]
        public string Review { get; set; }

        [NotMapped]
        public string Department { get; set; }

        [NotMapped]

        public string Subject { get; set; }



    }
}

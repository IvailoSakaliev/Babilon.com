using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Login
{
    public class RegisterVM
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [Display(Name = "First name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [Display(Name = "Facultet Number")]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(6)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
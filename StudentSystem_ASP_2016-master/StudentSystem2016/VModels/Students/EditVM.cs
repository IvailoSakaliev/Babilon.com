using DataAcsess.Enum;
using DataAcsess.Models;
using StudentSystem2016.VModels.Lectures;
using StudentSystem2016.VModels.Scolarships;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Students
{
    public class EditVM : EditPersoneVM
    {
        [Required]
        [MaxLength(1)]
        public string Course { get; set; }

        [Required]
        [MaxLength(1)]
        public string  Groups { get; set; }

        [Required]
        public OKS OKS { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public Roles Role { get; set; }

        [Required]
        public SpecialtyName Specialty { get; set; }

        public int login_id { get; set; }


    }
  
}
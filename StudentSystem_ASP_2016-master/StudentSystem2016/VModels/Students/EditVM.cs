using DataAcsess.Enum;
using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Students
{
    public class EditVM : EditPersoneVM
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(1)]
        public string Course { get; set; }

        [Required]
        [MaxLength(1)]
        public string  Groups { get; set; }

        [Required]
        public string Inspector { get; set; }

        [Required]
        public OKS OKS { get; set; }

        public string Inmage { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        public string Mobile { get; set; }

        
    }
  
}
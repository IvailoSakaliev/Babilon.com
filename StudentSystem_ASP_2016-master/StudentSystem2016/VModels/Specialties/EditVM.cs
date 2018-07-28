using DataAcsess.Enum;
using DataAcsess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Specialties
{
    public class EditVM
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        [Display(Name = "Specialties")]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(1)]
        [Display(Name = "Year of study")]
        public string YearOFStudy { get; set; }

        [Required]
        public string Inspector { get; set; }

        [Required]
        public OKS OKS { get; set; }

        public List<Facultet> Facultet { get; set; }
    }
}
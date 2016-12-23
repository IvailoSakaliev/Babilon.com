using DataAcsess.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Specialty
{
    public class EditVM
    {
        public int ID { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(4)]
        public string YearOFStudy { get; set; }

        [Required]
        public string Inspector { get; set; }

        [Required]
        public OKS OKS { get; set; }
    }
}
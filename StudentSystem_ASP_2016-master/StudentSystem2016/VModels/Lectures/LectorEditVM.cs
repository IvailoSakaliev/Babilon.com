using DataAcsess.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Lectures
{
    public class LectorEditVM: EditPersoneVM
    {
        [Required]
        [MaxLength(4)]
        [MinLength(1)]
        public string Kabinet { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string Mobile { get; set; }

        [Required]
        public Roles Role { get; set; }
    }
}
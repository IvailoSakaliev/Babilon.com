using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels.Scolarships
{
    public class EditVM
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(1)]
        public string Srok { get; set; }

        [Required]
        public DateTime StartData { get; set; }

        [Required]
        public DateTime DeadLine { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(5)]
        public string Size { get; set; }

    }
}
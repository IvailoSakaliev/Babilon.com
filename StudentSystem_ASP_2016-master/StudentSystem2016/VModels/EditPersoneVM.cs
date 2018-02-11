using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentSystem2016.VModels
{
    public class EditPersoneVM
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]

        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string Password { get; set; }
    }
}
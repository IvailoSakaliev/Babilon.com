using System.ComponentModel.DataAnnotations;

namespace StudentSystem2016.VModels
{
    public class EditPersoneVM
    {
        public int ID { get; set; }
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
        [MinLength(6)]
        [MaxLength(10)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Schedule_CodeFirstModel.Models
{
    public class Teacher
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

    }
}
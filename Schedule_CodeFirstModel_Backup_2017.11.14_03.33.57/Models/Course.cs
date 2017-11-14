using System.ComponentModel.DataAnnotations;

namespace Schedule_CodeFirstModel.Models
{
    public class Course
    {
        [Required]
        public int Id { get; set; }
        public int Number { get; set; }
    }
}
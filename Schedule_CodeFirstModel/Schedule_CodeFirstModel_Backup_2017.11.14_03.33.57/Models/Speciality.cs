using System.ComponentModel.DataAnnotations;

namespace Schedule_CodeFirstModel.Models
{
    public class Speciality
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
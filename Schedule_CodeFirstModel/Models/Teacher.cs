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
        public int UniversityId { get; set; }
        public string Address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public virtual University University { get; set; }
    }
}
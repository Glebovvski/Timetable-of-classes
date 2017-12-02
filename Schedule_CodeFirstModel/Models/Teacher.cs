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
        public int SubjectId { get; set; }
        [Display(Name = "Subject")]
        public virtual Subject Subject { get; set; }
    }
}
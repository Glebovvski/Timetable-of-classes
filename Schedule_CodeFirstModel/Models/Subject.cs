using System.ComponentModel.DataAnnotations;

namespace Schedule_CodeFirstModel.Models
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Subject")]
        public string SubjectName { get; set; }

        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

    }
}
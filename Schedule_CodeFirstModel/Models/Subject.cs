using System.ComponentModel.DataAnnotations;

namespace Schedule_CodeFirstModel.Models
{
    public class Subject
    {
        [Required]
        public int Id { get; set; }
        public string SubjectName { get; set; }
    }
}
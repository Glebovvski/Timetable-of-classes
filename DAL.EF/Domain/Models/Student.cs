using System.ComponentModel.DataAnnotations;

namespace Schedule_CodeFirstModel.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
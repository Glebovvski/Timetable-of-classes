using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class Group
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "Group Name")]
        public string GroupName { get; set; }
        [Display(Name = "Course")]
        [Range(1,6)]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        [Range(1,22)]
        public int Students { get; set; }
        [Display(Name = "Speciality")]
        public int SpecialityId { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
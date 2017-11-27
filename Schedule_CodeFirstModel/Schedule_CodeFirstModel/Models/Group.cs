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
        
        public string GroupName { get; set; }
        public Course Course { get; set; }
        public int Students { get; set; }
        public Speciality Speciality { get; set; }
    }
}
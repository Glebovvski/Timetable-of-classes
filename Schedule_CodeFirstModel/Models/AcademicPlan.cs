using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class AcademicPlan
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public Speciality Speciality { get; set; }
        [Required]
        public Semestre Semestre { get; set; }
        public Subject Subject { get; set; }
    }
}
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
        [Display(Name = "Speciality")]
        public int SpecialityId { get; set; }
        public virtual Speciality Speciality { get; set; }

        [Required]
        [Display(Name = "Semestre")]
        public int SemestreId { get; set; }
        public virtual Semestre Semestre { get; set; }

        [Display(Name = "Subject")]
        [Required]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
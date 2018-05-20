using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class StudentStatus
    {
        public int Id { get; set; }
        [Display(Name = "Has Scolarship?")]
        public bool Scholarship { get; set; }
        [Display(Name = "Is Single Child?")]
        public bool SingleChild { get; set; }
        [Display(Name = "Is Average score is greater than 4.0?")]
        public bool AverageScoreEqualsOrLessThanNeeded { get; set; }
        [Display(Name = "Is Orphan?")]
        public bool Orphan { get; set; }
        [Display(Name = "Is Disabled Person?")]
        public bool DisabledPerson { get; set; }
    }
}
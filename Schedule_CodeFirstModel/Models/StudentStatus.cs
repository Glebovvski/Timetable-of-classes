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
        public bool Scholarship { get; set; }
        public bool SingleChild { get; set; }
        [Display(Name = "Average score is greater than 4.0")]
        public bool AverageScoreEqualsOrLessThanNeeded { get; set; }
        public bool Orphan { get; set; }
        public bool DisabledPerson { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class TeachersBookkeeping
    {
        public int Id { get; set; }
        
        public int TeacherId { get; set; }
        public virtual Teacher Teachers { get; set; }

        public int Hours { get; set; }
        [Display(Name ="Experience in months")]
        public int Experience_months { get; set; }
        public double Salary { get; set; }
        public double ActualSalary { get; set; }
        public double Taxes { get; set; }
        public double Bonus { get; set; }
    }
}
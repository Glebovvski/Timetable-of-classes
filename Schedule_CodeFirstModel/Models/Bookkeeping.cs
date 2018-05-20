using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class Bookkeeping
    {
        public int Id { get; set; }
        [Display(Name = "Sum to pay")]
        public double SumToPay { get; set; }
        public double DiscountSum { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int StudentStatusId { get; set; }
        public virtual StudentStatus StudentStatus { get; set; }
    }
}
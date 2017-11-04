using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public int ClassNumber { get; set; }
        public Subject SubjectId { get; set; }
        public Teacher TeacherId { get; set; }
        public Room Room { get; set; }
    }
}
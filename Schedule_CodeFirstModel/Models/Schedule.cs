using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    
    public class Schedule
    {
        public int Id { get; set; }
        
        public Group Group { get; set; }
        public string Day { get; set; }
        public Week WeekNumber { get; set; }
        public Class Class { get; set; }
        public Teacher Teacher { get; set; }
        public Room Room { get; set; }
        public Subject Subject { get; set; }
    }
}
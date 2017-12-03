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

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public string Day { get; set; }
        public Week WeekNumber { get; set; }

        public Class Class { get; set; }

        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        [Display(Name = "Room")]
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        [Display(Name = "Subject")]
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
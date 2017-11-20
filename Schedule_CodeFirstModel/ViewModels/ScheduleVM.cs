using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class ScheduleVM
    {
        public string Day { get; set; }// = new List<string>() { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        public int Number { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH':'mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }
        [DisplayFormat(DataFormatString = "{0:HH':'mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }
        public int Room { get; set; }
        public int PlacesAmount { get; set; }
        public string Name { get; set; }
        public string SubjectName { get; set; }
    }
}
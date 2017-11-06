using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class ScheduleVM
    {
        public string Day { get; set; }
        public int ClassNumber { get; set; }
        public int Room { get; set; }
        public int PlacesAmount { get; set; }
        public string Name { get; set; }
        public string SubjectName { get; set; }
    }
}
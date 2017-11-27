using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class GroupVM
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public int Students { get; set; }
        public int Course { get; set; }
        public string Speciality { get; set; }
    }
}
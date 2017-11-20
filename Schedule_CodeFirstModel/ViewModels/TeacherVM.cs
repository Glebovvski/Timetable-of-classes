using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.ViewModels
{
    public class TeacherVM
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }
        public string SubjectName { get; set; }
    }
}
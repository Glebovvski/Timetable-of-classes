using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class Semestre
    {
        [Required]
        public int Id { get; set; }
        public int Number { get; set; }
    }
}
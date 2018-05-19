using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Schedule_CodeFirstModel.Models
{
    public class University
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public enum Week
    {
        [Display(Name = "First")]
        firstWeek = 1,
        [Display(Name = "Second")]
        secondWeek = 2
    }
}
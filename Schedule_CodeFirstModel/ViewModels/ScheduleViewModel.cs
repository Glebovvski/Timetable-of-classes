using MvcSchedule.Objects;
using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.ViewModels
{
    public class ScheduleViewModel
    {
        public List<ScheduleVM> Data { get; set; }
        public MvcScheduleCalendarOptions Options { get; set; }

        public ScheduleViewModel()
        {
            Data = new List<ScheduleVM>();
            Options = new MvcScheduleCalendarOptions();
        }
    }
}
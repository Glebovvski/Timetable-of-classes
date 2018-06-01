using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Schedule_CodeFirstModel.Domain.Models
{
    public class TeacherSchedule : Schedule
    {
        public override List<Schedule> GetSchedule(int teacherId)
        {
            ScheduleContext context = new ScheduleContext();
            return context.Schedules.Where(x => x.TeacherId == teacherId).Include(d => d.Subject).Include(r => r.Room).Include(c => c.Class).Include(x => x.Group).ToList();
        }
    }
}
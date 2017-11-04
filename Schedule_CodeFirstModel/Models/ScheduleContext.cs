using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class ScheduleContext : DbContext
    {
        public ScheduleContext():base("ScheduleContext")
        {
        }
        public DbSet<AcademicPlan> AcademicPlans { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Semestre> Semestres { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
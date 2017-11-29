using MvcSchedule.Objects;
using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedule_CodeFirstModel.Controllers
{
    public class HomeController : Controller
    {
        private ScheduleContext context; 

        public HomeController()
        {
            context = new ScheduleContext();
        }

        public ActionResult Index()
        {
            var groups = context.Groups.Include(spec=>spec.Speciality).Include(c=>c.Course).ToList();
            return View(groups);
        }

        public ActionResult GetSchedule(int id)
        {
            //var sql = @"GetSchedule {0}";
            //var schedule = context.Database.SqlQuery<ScheduleVM>(sql, id).ToList();

            var days = new List<string>() { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            //var pairs = new List<string>() { "1, 2, 3, 4, 5 };
            var times = new List<string>() { "8:30-10:05", "10:25-12:00", "12:20-13:55", "14:15-15:50", "16:10-17:45" };
            ViewBag.Days = days;
            //ViewBag.Pairs = pairs;
            ViewBag.Times = times;
            var schedule = context.Schedules.Where(x => x.Group.Id == id).Include(s => s.Subject).Include(d => d.Teacher).Include(r => r.Room).Include(c=>c.Class).ToList();
            ViewBag.Schedule = schedule;
            return View(schedule);
        }

        public ActionResult Teachers()
        {
            var sql = @"GetTeachers";
            var teachers = context.Database.SqlQuery<Teacher>(sql).ToList();
            return View(teachers);
        }

        public ActionResult Specialities()
        {
            var sql = @"GetSpecialities";
            var specs = context.Database.SqlQuery<Speciality>(sql).ToList();

            return View(specs);
        }
    }
}
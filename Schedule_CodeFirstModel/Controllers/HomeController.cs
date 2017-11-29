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
            var days = new List<string>() { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            ViewBag.Days = days;
            var schedule = context.Schedules.Where(x => x.Group.Id == id).Include(s => s.Subject).Include(d => d.Teacher).Include(r => r.Room).Include(c=>c.Class).ToList();
            return View(schedule);
        }

        public ActionResult Teachers()
        {
            var teachers = context.Teachers.Include(x => x.Subject).ToList();
            return View(teachers);
        }

        public ActionResult Specialities()
        {
            var specs = context.Specialities.ToList();
            return View(specs);
        }

        public ActionResult GroupsBySpec(int id)
        {
            var groupsbyspec = context.Groups.Where(x => x.Speciality.Id == id).Include(spec => spec.Speciality).Include(c => c.Course).ToList();
            return View("Index", groupsbyspec);
        }
    }
}
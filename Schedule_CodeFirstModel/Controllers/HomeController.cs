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

            var schedule = context.Schedules.Where(x => x.Group.Id == id).Include(s => s.Subject).Include(n => n.Class).Include(d => d.Teacher).Include(r => r.Room).ToList();

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
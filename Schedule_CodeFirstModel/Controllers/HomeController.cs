using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedule_CodeFirstModel.Controllers
{
    public class HomeController : Controller
    {
        private ScheduleContext context = new ScheduleContext();

        public HomeController(){}
        public HomeController(ScheduleContext _context)
        {
            context = _context;
        }

        public ActionResult Index()
        {
            var specialities = context.Specialities.ToList();
            var courses = context.Courses.ToList();
            var groups = context.Groups.ToList();

            var groupsRes = groups.Join(
                courses,
                gc => gc.Course.Id,
                c => c.Id,
                (gc, c) => new GroupVM()
                {
                    Id = gc.Id,
                    GroupName = gc.GroupName,
                    Students = gc.Students,
                    Course = c.Number,
                    Speciality = gc.Speciality.Name
                }).ToList();
            
            return View(groupsRes);
        }

        public ActionResult GetSchedule(int id)
        {
            var sql = @"GetSchedule {0}";
            var schedule = context.Database.SqlQuery<ScheduleVM>(sql, id).ToList();

            return View(schedule);
        }
    }
}
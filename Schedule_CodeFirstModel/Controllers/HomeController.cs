using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
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
            var groups = context.Groups.ToList();
            return View(groups);
        }

        public ActionResult GetSchedule(int id)
        {
            var sql = @"GetSchedule {0}";
            var schedule = context.Database.SqlQuery<ScheduleVM>(sql, id).ToList();
            return View(schedule);
        }
    }
}
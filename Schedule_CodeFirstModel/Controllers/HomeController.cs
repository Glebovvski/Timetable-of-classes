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
        private ScheduleContext context;
        public HomeController()
        {

        }
        public HomeController(ScheduleContext _context)
        {
            context = _context;
        }
        public ActionResult Index()
        {
            var context = new ScheduleContext();
            var groups = context.Groups.ToList();
            return View(groups);
        }
    }
}
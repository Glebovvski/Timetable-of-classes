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
            //var sql = @"GetSchedule {0}";
            //var schedule = context.Database.SqlQuery<ScheduleVM>(sql, id).ToList();

            var schedules = context.Schedules.Where(x => x.Group.Id == id).ToList();
            var rooms = context.Rooms.ToList();
            var teachers = context.Teachers.ToList();
            var subjects = context.Subjects.ToList();
            
            var schedule = schedules.Join(
                subjects,
                ss => ss.Subject.Id,
                s => s.Id,
                (ss, s) => new ScheduleVM()
                {
                    Day = ss.Day,
                    ClassNumber = ss.ClassNumber,
                    Room = ss.Room.Number,
                    PlacesAmount = ss.Room.PlacesAmount,
                    Name = ss.Teacher.Name,
                    SubjectName = ss.Subject.SubjectName
                }
                ).ToList();
            return View(schedule);
        }
    }
}
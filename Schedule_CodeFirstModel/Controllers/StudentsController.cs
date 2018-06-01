using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedule_CodeFirstModel.Controllers
{
    public class StudentsController : Controller
    {
        private ScheduleContext context;
        public StudentsController()
        {
            context = new ScheduleContext();
        }
        // GET: Students
        /// <summary>
        /// Gets the list of students in the group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            var students = context.Students.Where(x => x.GroupId == id).ToList();
            return View(students);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            SelectList groups = new SelectList(context.Groups, "Id", "GroupName");
            ViewBag.Groups = groups;
            return View();
        }

        // POST: Students/Create
        /// <summary>
        /// Creates new Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    return Redirect("~/Students/Index/" + student.GroupId);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = context.Students.Find(id);
            SelectList groups = new SelectList(context.Groups, "Id", "GroupName", student.GroupId);
            ViewBag.Groups = groups;
            return View(student);
        }

        // POST: Students/Edit/5
        /// <summary>
        /// Updates information about student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(student).State = EntityState.Modified;
                    context.SaveChanges();
                    return Redirect("~/Students/Index/" + student.GroupId);
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(context.Students.Find(id));
        }

        // POST: Students/Delete/5
        /// <summary>
        /// Deletes Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                context.Students.Remove(context.Students.Find(id));
                context.SaveChanges();
                return Redirect("~/Home/Index/");
            }
            catch
            {
                return View();
            }
        }
    }
}

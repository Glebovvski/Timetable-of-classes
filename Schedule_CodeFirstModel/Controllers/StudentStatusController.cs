using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schedule_CodeFirstModel.Controllers
{
    public class StudentStatusController : Controller
    {
        private ScheduleContext context;
        public StudentStatusController()
        {
            context = new ScheduleContext();
        }
        // GET: StudentStatus
        public ActionResult Index()
        {
            return View(context.StudentStatuses.ToList());
        }

        // GET: StudentStatus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentStatus/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentStatus/Edit/5
        public ActionResult Edit(int id)
        {
            return View(context.StudentStatuses.Find(id));
        }

        // POST: StudentStatus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentStatus/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentStatus/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

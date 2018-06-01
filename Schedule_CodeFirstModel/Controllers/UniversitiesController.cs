using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Schedule_CodeFirstModel.Controllers
{
    public class UniversitiesController : Controller
    {
        private ScheduleContext context;
        public UniversitiesController()
        {
            context = new ScheduleContext();
        }
        // GET: Universities
        /// <summary>
        /// Gets the list of universities
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var univers = context.Universities.ToList();
            return View(univers);
        }

        /// <summary>
        /// Gets map with universities
        /// </summary>
        /// <returns></returns>
        public ActionResult Universities()
        {
            XmlDocument doc = new XmlDocument();
            var xml = context.Database.SqlQuery<string>("GetUnivers").ToList();
            doc.LoadXml(xml[0].ToString());
            doc.Save(@"D:\VSProjects\GIS_KURSACH\Schedule_CodeFirstModel\map.xml");
            return View();
        }

        // GET: Universities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Universities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universities/Create
        /// <summary>
        /// Creates new university
        /// </summary>
        /// <param name="university"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(University university)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Universities.Add(university);
                    context.SaveChanges();
                    return RedirectToAction("Universities");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Universities/Edit/5
        public ActionResult Edit(int id)
        {
            return View(context.Universities.Find(id));
        }

        // POST: Universities/Edit/5
        /// <summary>
        /// Updates information about University
        /// </summary>
        /// <param name="id"></param>
        /// <param name="university"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, University university)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(university).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Universities");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Universities/Delete/5
        public ActionResult Delete(int id)
        {
            return View(context.Universities.Find(id));
        }

        // POST: Universities/Delete/5
        /// <summary>
        /// Deletes University from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                context.Universities.Remove(context.Universities.Find(id));
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

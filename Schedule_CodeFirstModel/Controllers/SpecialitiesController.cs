using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Schedule_CodeFirstModel.Models;

namespace Schedule_CodeFirstModel.Controllers
{
    public class SpecialitiesController : Controller
    {
        private ScheduleContext db = new ScheduleContext();

        // GET: Specialities
        /// <summary>
        /// Gets the list of specialities
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            return View(await db.Specialities.ToListAsync());
        }

        // GET: Specialities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specialities/Create
        /// <summary>
        /// Creates new speciality
        /// </summary>
        /// <param name="speciality"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                db.Specialities.Add(speciality);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(speciality);
        }

        // GET: Specialities/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speciality speciality = await db.Specialities.FindAsync(id);
            if (speciality == null)
            {
                return HttpNotFound();
            }
            return View(speciality);
        }

        /// <summary>
        /// Updates information about speciality
        /// </summary>
        /// <param name="speciality"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speciality).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(speciality);
        }

        // GET: Specialities/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speciality speciality = await db.Specialities.FindAsync(id);
            if (speciality == null)
            {
                return HttpNotFound();
            }
            return View(speciality);
        }

        // POST: Specialities/Delete/5
        /// <summary>
        /// Deletes speciality
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Speciality speciality = await db.Specialities.FindAsync(id);
            db.Specialities.Remove(speciality);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

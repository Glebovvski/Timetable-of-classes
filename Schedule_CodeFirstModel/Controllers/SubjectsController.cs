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
    public class SubjectsController : Controller
    {
        private ScheduleContext db = new ScheduleContext();

        // GET: Subjects
        public async Task<ActionResult> Index(int? id)
        {
            if (id == null)
                return Redirect("~/Universities/Index");
            else
            {
                var subjects = db.Subjects.Include(s => s.Teacher).Where(x => x.Teacher.UniversityId == id);
                return View(await subjects.ToListAsync());
            }
        }

        public ActionResult GeneratePDF()
        {
            return new Rotativa.ActionAsPdf("Index");
        }
        public ActionResult CreateTeacher()
        {
            var teachers = db.Universities.ToList();
            SelectList sl = new SelectList(teachers, "Id", "Name");
            ViewBag.Univers = sl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTeacher([Bind(Include = "Id,Name,UniversityId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }
        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SubjectName,TeacherId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", subject.TeacherId);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await db.Subjects.FindAsync(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", subject.TeacherId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SubjectName,TeacherId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", subject.TeacherId);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = await db.Subjects.FindAsync(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Subject subject = await db.Subjects.FindAsync(id);
            db.Subjects.Remove(subject);
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

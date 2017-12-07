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
    public class AcademicPlansController : Controller
    {
        private ScheduleContext db = new ScheduleContext();

        // GET: AcademicPlans/Create
        public ActionResult Create()
        {
            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "Id");
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectName");
            return View();
        }

        // POST: AcademicPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,SpecialityId,SemestreId,SubjectId")] AcademicPlan academicPlan)
        {
            if (ModelState.IsValid)
            {
                db.AcademicPlans.Add(academicPlan);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "Id", academicPlan.SemestreId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", academicPlan.SpecialityId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectName", academicPlan.SubjectId);
            return View(academicPlan);
        }

        // GET: AcademicPlans/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicPlan academicPlan = await db.AcademicPlans.FindAsync(id);
            if (academicPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "Id", academicPlan.SemestreId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", academicPlan.SpecialityId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectName", academicPlan.SubjectId);
            return View(academicPlan);
        }

        // POST: AcademicPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,SpecialityId,SemestreId,SubjectId")] AcademicPlan academicPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academicPlan).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "Id", academicPlan.SemestreId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", academicPlan.SpecialityId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectName", academicPlan.SubjectId);
            return View(academicPlan);
        }

        // GET: AcademicPlans/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicPlan academicPlan = await db.AcademicPlans.FindAsync(id);
            if (academicPlan == null)
            {
                return HttpNotFound();
            }
            return View(academicPlan);
        }

        // POST: AcademicPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AcademicPlan academicPlan = await db.AcademicPlans.FindAsync(id);
            db.AcademicPlans.Remove(academicPlan);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Plan(int id)
        {
            var plan =  await db.AcademicPlans.Where(x => x.SpecialityId == id).Include(z => z.Subject).Include(r => r.Semestre).ToListAsync();
            if (plan == null)
            {
                return HttpNotFound();
            }
            return View(plan);
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

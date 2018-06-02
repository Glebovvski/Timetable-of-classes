using Ninject;
using Schedule_CodeFirstModel.Models;
using Schedule_CodeFirstModel.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Schedule_CodeFirstModel.Controllers
{
    public class AcademicPlansController : Controller
    {
        private ScheduleContext db = new ScheduleContext();
        private readonly IRepository<AcademicPlan> repo;
        public AcademicPlansController(IRepository<AcademicPlan> repo)
        {
            this.repo = repo;
        }
        // GET: AcademicPlans/Create
        public ActionResult Create()
        {
            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "Id");
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectName");
            return View();
        }

        // POST: AcademicPlans/Create
        /// <summary>
        /// Creates new Academic Plan
        /// </summary>
        /// <param name="academicPlan"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SpecialityId,SemestreId,SubjectId")] AcademicPlan academicPlan)
        {
            if (ModelState.IsValid)
            {
                repo.Create(academicPlan);
                return RedirectToAction("Index");
            }

            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "Id", academicPlan.SemestreId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", academicPlan.SpecialityId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectName", academicPlan.SubjectId);
            return View(academicPlan);
        }

        // GET: AcademicPlans/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicPlan academicPlan = repo.Read(id);
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
        /// <summary>
        /// Updates existing Academic Plan
        /// </summary>
        /// <param name="academicPlan"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SpecialityId,SemestreId,SubjectId")] AcademicPlan academicPlan)
        {
            if (ModelState.IsValid)
            {
                repo.Update(academicPlan);
                return RedirectToAction("Index");
            }
            ViewBag.SemestreId = new SelectList(db.Semestres, "Id", "Id", academicPlan.SemestreId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", academicPlan.SpecialityId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "SubjectName", academicPlan.SubjectId);
            return View(academicPlan);
        }

        // GET: AcademicPlans/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AcademicPlan academicPlan = repo.Read(id);
            if (academicPlan == null)
            {
                return HttpNotFound();
            }
            return View(academicPlan);
        }

        // POST: AcademicPlans/Delete/5
        /// <summary>
        /// Deletes Academic Plan from Database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Gets Academic Plan by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Plan(int id)
        {
            AcademicPlanRepository rep = new AcademicPlanRepository();
            var plan = rep.GetPlan(id);
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
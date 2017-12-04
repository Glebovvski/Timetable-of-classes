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
    public class SchedulesController : Controller
    {
        private ScheduleContext db = new ScheduleContext();

        // GET: Schedules
        public async Task<ActionResult> Index(int? id)
        {
            var days = new List<string>() { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            ViewBag.Days = days;
            var schedule = await db.Schedules.Where(x => x.Group.Id == id).Include(d => d.Teacher).Include(r => r.Room).Include(c => c.Class).ToListAsync();
            return View(schedule);
        }

        // GET: Schedules/Create
        public ActionResult Create()
        {
            SelectList groups = new SelectList(db.Groups, "Id", "GroupName");
            ViewBag.Groups = groups;
            SelectList teachers = new SelectList(db.Teachers, "Id", "Name");
            ViewBag.Teachers = teachers;
            SelectList rooms = new SelectList(db.Rooms, "Id", "Number", "PlacesAmount");
            ViewBag.Rooms = rooms;
            SelectList subj = new SelectList(db.Subjects, "Id", "SubjectName");
            ViewBag.Subjects = subj;
            SelectList classes = new SelectList(db.Classes, "Id", "Number");
            ViewBag.Classes = classes;

            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Day,ClassId,WeekNumber,TeacherId,RoomId,SubjectId,GroupId")] Schedule schedule)
        {
            var check = db.Schedules.Where(x => x.Group.Id == schedule.GroupId).Where(x => x.Day == schedule.Day).Where(x => x.Class.Id == schedule.ClassId).Where(x => x.WeekNumber == schedule.WeekNumber).FirstOrDefault();
            if (check != null)
            {
                SelectList teachers = new SelectList(db.Teachers, "Id", "Name");
                ViewBag.Teachers = teachers;
                SelectList rooms = new SelectList(db.Rooms, "Id", "Number", "PlacesAmount");
                ViewBag.Rooms = rooms;
                SelectList subj = new SelectList(db.Subjects, "Id", "SubjectName");
                ViewBag.Subjects = subj;
                SelectList classes = new SelectList(db.Classes, "Id", "Number");
                ViewBag.Classes = classes;
                SelectList groups = new SelectList(db.Groups, "Id", "GroupName");
                ViewBag.Groups = groups;
                ModelState.AddModelError("GroupId", "Schedule for this class is already created! You can Edit it on the form");
            }
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                await db.SaveChangesAsync();
                return RedirectToAction("Index/" + schedule.GroupId);
            }

            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = await db.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            SelectList teachers = new SelectList(db.Teachers, "Id", "Name", schedule.TeacherId);
            ViewBag.Teachers = teachers;
            SelectList rooms = new SelectList(db.Rooms, "Id", "Number", "PlacesAmount",schedule.RoomId);
            ViewBag.Rooms = rooms;
            SelectList subj = new SelectList(db.Subjects, "Id", "SubjectName",schedule.SubjectId);
            ViewBag.Subjects = subj;
            SelectList groups = new SelectList(db.Groups, "Id", "GroupName");
            ViewBag.Groups = groups;
            SelectList classes = new SelectList(db.Classes, "Id", "Number");
            ViewBag.Classes = classes;

            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,GroupId,Day,ClassId,WeekNumber,TeacherId,RoomId,SubjectId")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index/"+schedule.GroupId);
            }
            return RedirectToAction("Index",schedule.GroupId);
        }

        // GET: Schedules/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = await db.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Schedule schedule = await db.Schedules.FindAsync(id);
            db.Schedules.Remove(schedule);
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

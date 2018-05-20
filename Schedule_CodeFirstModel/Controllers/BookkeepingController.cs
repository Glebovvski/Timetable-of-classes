using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Schedule_CodeFirstModel.Controllers
{
    public class BookkeepingController : Controller
    {
        private ScheduleContext context;

        public BookkeepingController()
        {
            context = new ScheduleContext();
        }
        // GET: Bookkeeping
        public ActionResult Index(int? id)
        {
            CalculateSumToPay();
            if (id == null)
            {
                return Redirect("~/Universities/Index");
            }
            else
            {
                var books = context.Bookkeepings.Include(x => x.Student).Include(st => st.StudentStatus).Where(x => x.Student.GroupId == id).ToList();
                return View(books);
            }
        }

        public void CalculateSumToPay()
        {
            var books = context.Bookkeepings.ToList();
            foreach (var item in books)
            {
                double defaultSum = item.SumToPay;
                if (item.StudentStatus.AverageScoreEqualsOrLessThanNeeded)
                    defaultSum *= 0.9;
                if (item.StudentStatus.DisabledPerson)
                    defaultSum *= 0.5;
                if (item.StudentStatus.Orphan)
                    defaultSum *= 0.5;
                if (item.StudentStatus.Scholarship)
                    defaultSum *= 0.95;
                if (!item.StudentStatus.SingleChild)
                    defaultSum *= 0.9;
                item.DiscountSum = defaultSum;
                context.SaveChanges();
            }
        }

        // GET: Bookkeeping/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bookkeeping/Create
        public ActionResult Create()
        {
            var list = new List<Student>();
            var students = context.Bookkeepings.Select(x => x.StudentId).ToList();
            var stList = context.Students.ToList();
            foreach (var item in stList)
            {
                if (!students.Contains(item.Id))
                {
                    list.Add(item);
                }
            }
            SelectList st = new SelectList(list, "Id", "Name");
            ViewBag.Students = st;
            return View();
        }

        // POST: Bookkeeping/Create
        [HttpPost]
        public ActionResult Create(Bookkeeping bookkeeping)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Bookkeepings.Add(bookkeeping);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(bookkeeping);
            }
            catch
            {
                return View();
            }
        }

        // GET: Bookkeeping/Edit/5
        public ActionResult Edit(int id)
        {
            Bookkeeping book = context.Bookkeepings.Include(x => x.StudentStatus).Where(x=>x.Id == id).First();
            return View(book);
        }

        // POST: Bookkeeping/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "Id,StudentStatusId,StudentStatus,SumToPay,StudentId,Student")]Bookkeeping boo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    boo.StudentId = context.Bookkeepings.First(x => x.Id == id).StudentId;
                    boo.Student = context.Students.Where(x => x.Id == boo.StudentId).First();
                    boo.StudentStatusId = context.Bookkeepings.First(x => x.Id == id).StudentStatusId;
                    boo.StudentStatus.Id = boo.StudentStatusId;
                    Bookkeeping oldBook = context.Bookkeepings.First(x => x.Id == id);
                    context.Bookkeepings.Remove(oldBook);
                    context.Bookkeepings.Add(boo);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                return View(boo);
            }
        }

        // GET: Bookkeeping/Delete/5
        public ActionResult Delete(int id)
        {
            return View(context.Bookkeepings.Find(id));
        }

        // POST: Bookkeeping/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Bookkeeping bookkeeping)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Bookkeepings.Remove(context.Bookkeepings.Find(id));
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(bookkeeping);
            }
            catch
            {
                return View();
            }
        }
    }
}

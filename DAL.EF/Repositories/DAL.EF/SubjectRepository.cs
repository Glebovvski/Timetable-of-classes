using Schedule_CodeFirstModel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Schedule_CodeFirstModel.Repositories
{
    public class SubjectRepository : IRepository<Subject>
    {
        public SubjectRepository()
        {
            
        }

        public void Create(Subject data)
        {
            ScheduleContext db = new ScheduleContext();
            db.Subjects.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            ScheduleContext db = new ScheduleContext();
            var subj = db.Subjects.Find(id);
            db.Subjects.Remove(subj);
        }

        public List<Subject> Read()
        {
            ScheduleContext db = new ScheduleContext();
            var subjects = db.Subjects.ToList();
            return subjects;
        }

        public Subject Read(int id)
        {
            ScheduleContext db = new ScheduleContext();
            var subj = db.Subjects.Find(id);
            return subj;
        }

        public void Update(Subject data)
        {
            ScheduleContext db = new ScheduleContext();
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
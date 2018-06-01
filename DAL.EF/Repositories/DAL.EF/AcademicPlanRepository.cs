using Schedule_CodeFirstModel.Models;
using Schedule_CodeFirstModel.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Schedule_CodeFirstModel.Models
{
    public class AcademicPlanRepository:IRepository<AcademicPlan>
    {
        public void Create(AcademicPlan data)
        {
            ScheduleContext db = new ScheduleContext();
            db.AcademicPlans.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            ScheduleContext db = new ScheduleContext();
            var plan = db.AcademicPlans.Find(id);
            if (plan != null)
            {
                db.AcademicPlans.Remove(plan);
                db.SaveChanges();
            }
        }

        public List<AcademicPlan> Read()
        {
            ScheduleContext db = new ScheduleContext();
            var academicPlans = db.AcademicPlans.ToList();
            return academicPlans;
        }

        public AcademicPlan Read(int id)
        {
            ScheduleContext db = new ScheduleContext();
            AcademicPlan plan = db.AcademicPlans.Find(id);
            return plan;
        }

        public void Update(AcademicPlan data)
        {
            ScheduleContext db = new ScheduleContext();
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule_CodeFirstModel.Models;

namespace Schedule.Tests
{
    [TestClass]
    public class UnitTestAcademicPlan
    {
        [TestMethod]
        public void GetAcademPlanById()
        {
            AcademicPlanRepository academicPlan = new AcademicPlanRepository();
            AcademicPlan plan = academicPlan.Read(12);
            Assert.IsNotNull(plan);
        }

        [TestMethod]
        public void AddAcademicPlanTest()
        {
            AcademicPlanRepository rep = new AcademicPlanRepository();
            AcademicPlan plan = new AcademicPlan()
            {
                SemestreId = 1,
                SpecialityId = 3,
                SubjectId = 1
            };
        }

        [TestMethod]
        public void DeleteAcademPlanTest()
        {
            AcademicPlanRepository rep = new AcademicPlanRepository();
            rep.Delete(26);
            AcademicPlan plan = rep.Read(26);
            Assert.IsNull(plan);
        }

        [TestMethod]
        public void GetAllAcademicPlansTest()
        {
            AcademicPlanRepository rep = new AcademicPlanRepository();
            List<AcademicPlan> plans = rep.Read();
            Assert.IsNotNull(plans);
        }

        [TestMethod]
        public void UpdateAcademPlanTest()
        {
            AcademicPlanRepository rep = new AcademicPlanRepository();
            AcademicPlan plan = rep.Read(22);
            plan.SpecialityId = 2;
            rep.Update(plan);
            Assert.AreEqual(2, plan.SpecialityId);
        }

        [TestMethod]
        public void GetPlanTest()
        {
            AcademicPlanRepository repo = new AcademicPlanRepository();
            List<AcademicPlan> plans = repo.GetPlan(2);
            Assert.IsNotNull(plans);
        }
    }
}

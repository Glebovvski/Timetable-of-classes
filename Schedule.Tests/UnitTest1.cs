using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule_CodeFirstModel.Models;

namespace Schedule.Tests
{
    [TestClass]
    public class UnitTest1
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
            rep.Delete(27);
            AcademicPlan plan = rep.Read(27);
            Assert.IsNull(plan);
        }

        [TestMethod]
        public void GetAllAcademicPlans()
        {
            AcademicPlanRepository rep = new AcademicPlanRepository();
            List<AcademicPlan> plans = rep.Read();
            Assert.IsNotNull(plans);
        }
    }
}

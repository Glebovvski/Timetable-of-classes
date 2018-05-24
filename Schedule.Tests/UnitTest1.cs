using System;
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
    }
}

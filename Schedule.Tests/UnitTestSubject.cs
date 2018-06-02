using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schedule_CodeFirstModel.Models;
using Schedule_CodeFirstModel.Repositories;

namespace Schedule.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetSubjectById()
        {
            SubjectRepository academicPlan = new SubjectRepository();
            Subject plan = academicPlan.Read(11);
            Assert.IsNotNull(plan);
        }

        [TestMethod]
        public void AddSubjectTest()
        {
            SubjectRepository rep = new SubjectRepository();
            Subject plan = new Subject()
            {
                SubjectName = "Test",
                TeacherId = 1
            };
        }

        [TestMethod]
        public void DeleteSubjectTest()
        {
            SubjectRepository rep = new SubjectRepository();
            rep.Delete(16);
            Subject plan = rep.Read(16);
            Assert.IsNull(plan);
        }

        [TestMethod]
        public void GetAllSubjectsTest()
        {
            SubjectRepository rep = new SubjectRepository();
            List<Subject> plans = rep.Read();
            Assert.IsNotNull(plans);
        }

        [TestMethod]
        public void UpdateSubjectTest()
        {
            SubjectRepository rep = new SubjectRepository();
            Subject plan = rep.Read(11);
            plan.SubjectName = "Test2";
            rep.Update(plan);
            Assert.AreEqual("Test2", plan.SubjectName);
        }

        [TestMethod]
        public void GetSubjectsForUniverTest()
        {
            SubjectRepository repo = new SubjectRepository();
            List<Subject> subjects = repo.GetSubjectsForUniversity(2);
            Assert.IsNotNull(subjects);
        }
    }
}

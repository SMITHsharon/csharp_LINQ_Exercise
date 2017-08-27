using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_All
    {

        public List<Cohort> PracticeData { get; set; }
        public CohortBuilder CohortBuilder { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            CohortBuilder = new CohortBuilder();
            PracticeData = CohortBuilder.GenerateCohorts();
        }

        [TestCleanup]
        public void TearDown()
        {
            CohortBuilder = null;
            PracticeData = null;
        }

        [TestMethod]
        public void DoAllCohortsHaveTwoOrMoreJuniorInstructors()
        {
             //var doAll = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var doAll = PracticeData.All(cohort => cohort.JuniorInstructors.Count() > 1);
            //Assert.IsTrue(false); //<-- change false to doAll
            Assert.IsTrue(doAll);
        }

        [TestMethod]
        public void DoAllCohortsFiveStudents()
        {
            //var doAll = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var doAll = PracticeData.All(c => c.Students.Count() == 5);
            //Assert.IsTrue(false); //<-- change false to doAll
            Assert.IsTrue(doAll);
        }

        [TestMethod]
        public void DoAllCohortsHavePrimaryInstructorsBornIn1980s()
        {
            //var doAll = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var doAll = PracticeData.All(c => c.PrimaryInstructor.Birthday.Year >= 1980 
                                     && c.PrimaryInstructor.Birthday.Year < 1990) ;
            //Assert.IsFalse(true); //<-- change true to doAll
            Assert.IsFalse(doAll); 
        }

        [TestMethod]
        public void DoAllCohortsHaveActivePrimaryInstructors()
        {
            //var doAll = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var doAll = PracticeData.All(c => c.PrimaryInstructor.Active);
            //Assert.IsTrue(true); //<-- change true to doAll
            Assert.IsTrue(doAll); 
        }

        [TestMethod]
        public void DoAllStudentsInCohort1HaveFirstNamesThatContainTheLetterE()
        {
            //var doAll = PracticeData/*FILL IN LINQ EXPRESSION*/; //Hint: Cohort1 would be PracticeData[0]
            var doAll = PracticeData[0].Students.All(s => s.FirstName.ToLower().Contains("e")); 
            //Assert.IsTrue(false); //<-- change false to doAll
            Assert.IsTrue(doAll); 
        }

        [TestMethod]
        public void DoAllActiveCohortsHavePrimaryInstructorsWithFirstNamesThatContainTheLetterA()
        {
            //var doAll = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var doAll = PracticeData.All(c => c.PrimaryInstructor.FirstName.ToLower().Contains("a"));
            //Assert.IsFalse(false); //<-- change false to doAll
            Assert.IsFalse(doAll); 
        }
    }
}

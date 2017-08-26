using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_Any
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
        public void DoAnyCohortsHavePrimaryInstructorsBornIn1980s()
        {
            //var doAny = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var doAny = PracticeData.Any(cohort => cohort.PrimaryInstructor.Birthday.Year >= 1980 
                                                && cohort.PrimaryInstructor.Birthday.Year < 1990);
            //Assert.IsTrue(false); //<-- change false to doAny
            Assert.IsTrue(doAny); //<-- change false to doAny
        }

        [TestMethod]
        public void DoAnyCohortsHaveActivePrimaryInstructors()
        {
            //var doAny = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var doAny = PracticeData.Any(cohort => cohort.PrimaryInstructor.Active);
            //Assert.IsTrue(false); //<-- change false to doAny
            Assert.IsTrue(doAny); //<-- change false to doAny
        }

        [TestMethod]
        public void DoAnyActiveCohortsHave3JuniorInstructors()
        {
            //var doAny = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var doAny = PracticeData.Any(cohort => cohort.JuniorInstructors.Count() == 3);
            //Assert.IsTrue(false); //<-- change false to doAny
            Assert.IsTrue(doAny); //<-- change false to doAny
        }

        [TestMethod]
        public void AreAnyCohortsBothFullTimeAndNotActive()
        {
            //var doAny = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var doAny = PracticeData.Any(cohort => cohort.FullTime && !cohort.Active);
            //Assert.IsTrue(false); //<-- change false to doAny
            Assert.IsTrue(doAny); //<-- change false to doAny
        }

        [TestMethod]
        public void AreAnyStudentsInCohort3NotActiveAndBornInOctober()
        {
            //var doAny = PracticeData/*FILL IN LINQ EXPRESSION*/;  //HINT: Cohort3 is PracticeData[2]
            var doAny = PracticeData[2].Students.Any(student => !student.Active && student.Birthday.Month == 10); 
            //Assert.IsFalse(true); //<-- change true to doAny
            Assert.IsFalse(doAny); //<-- change true to doAny
        }

        [TestMethod]
        public void AreAnyJuniorInstructorsInCohort4NotActive()
        {
            //var doAny = PracticeData/*FILL IN LINQ EXPRESSION*/;  //HINT: Cohort4 is PracticeData[3]
            var doAny = PracticeData[3].JuniorInstructors.Any(instructor => !instructor.Active);  
            //Assert.IsFalse(true); //<-- change true to doAny
            Assert.IsFalse(doAny); //<-- change true to doAny
        }
    }
}

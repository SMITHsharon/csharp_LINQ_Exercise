using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_MethodChaining
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
        public void GetAllCohortsWithZacharyZohanAsPrimaryOrJuniorInstructor()
        {
            var jrInstructors = PracticeData.Where(cohort => cohort.JuniorInstructors.Any(instructor => instructor.FirstName == "Zachary" && instructor.LastName == "Zohan"));
            var primaryInstructors = PracticeData.Where(cohort => cohort.PrimaryInstructor.FirstName == "Zachary" && cohort.PrimaryInstructor.LastName == "Zohan");
            //var ActualCohorts = PracticeData/*FILL IN LINQ EXPRESSION*/.ToList();
            var ActualCohorts = primaryInstructors.Union(jrInstructors).ToList();                            
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort2, CohortBuilder.Cohort3 });
        }

        [TestMethod]
        public void GetAllCohortsWhereFullTimeIsFalseAndAllInstructorsAreActive()
        {
           //var ActualCohorts = PracticeData/*FILL IN LINQ EXPRESSION*/.ToList();
            var ActualCohorts = PracticeData.Where(c => (c.FullTime == false) && (c.PrimaryInstructor.Active == true)
                                             && (c.JuniorInstructors.All(instructor => instructor.Active)))
                                             .ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort1 });
        }

        [TestMethod]
        public void GetAllCohortsWhereAStudentOrInstructorFirstNameIsKate()
        {
            var studentKate = PracticeData.Where(c => c.Students.Any(student => student.FirstName == "Kate"));
            var primaryIntructorKate = PracticeData.Where(c => c.PrimaryInstructor.FirstName == "Kate");
            var jrInstructorKate = PracticeData.Where(c => c.JuniorInstructors.Any(instructor => instructor.FirstName == "Kate"));
            //var ActualCohorts = PracticeData/*FILL IN LINQ EXPRESSION*/.ToList();
            // ORDER MATTERS ... 
            //var ActualCohorts = studentKate.Union(primaryIntructorKate).Union(jrInstructorKate).ToList();
            //var ActualCohorts = primaryIntructorKate.Union(studentKate).Union(jrInstructorKate).ToList();
            var ActualCohorts = jrInstructorKate.Union(studentKate).Union(primaryIntructorKate).ToList();
            CollectionAssert.AreEqual(ActualCohorts, new List<Cohort> { CohortBuilder.Cohort1, CohortBuilder.Cohort3, CohortBuilder.Cohort4 });
        }

        [TestMethod]
        public void GetOldestStudent()
        {
            //var allStudents = PracticeData.SelectMany(c => c.Students).ToList();
            //var allStudents = PracticeData.SelectMany(c => c.Students);
            //var studentBdays = allStudents.OrderBy(s => s.Birthday);
            //var student = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var student = PracticeData.SelectMany(c => c.Students).OrderBy(s => s.Birthday).First();
            Assert.AreEqual(student, CohortBuilder.Student18);
        }

        [TestMethod]
        public void GetYoungestStudent()
        {
            //var student = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var student = PracticeData.SelectMany(c => c.Students).OrderByDescending(s => s.Birthday).First();
            Assert.AreEqual(student, CohortBuilder.Student3);
        }

        [TestMethod]
        public void GetAllInactiveStudentsByLastName()
        {
            var alphaStudents = PracticeData.SelectMany(c => c.Students).OrderBy(s => s.LastName);
            //var inactiveStudents = PracticeData.Students.
            //var ActualStudents = PracticeData/*FILL IN LINQ EXPRESSION*/.ToList();
            var ActualStudents = PracticeData.SelectMany(c => c.Students).OrderBy(s => s.LastName).Where(s => s.Active == false).ToList();
            CollectionAssert.AreEqual(ActualStudents, new List<Student> { CohortBuilder.Student2, CohortBuilder.Student11, CohortBuilder.Student12, CohortBuilder.Student17 });
        }
    }
}

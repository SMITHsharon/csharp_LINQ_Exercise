﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_MinMax //.Min & .Max
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
        public void WhatIsTheBirthdayOfTheYoungestStudentInCohort3()
        {
            //var maxValue = PracticeData/*FILL IN LINQ EXPRESSION*/; //HINT: Cohort3 is PracticeData[2]
            var maxValue = PracticeData[2].Students.Max(student => student.Birthday);
            //Assert.AreEqual(maxValue, new DateTime(1987, 8, 13));
            Assert.AreEqual(maxValue, new DateTime(1987, 8, 13));
        }

        [TestMethod]
        public void WhatIsTheBirthdayOfTheOldestStudentInCohort3()
        {
            //var minValue = PracticeData/*FILL IN LINQ EXPRESSION*/; //HINT: Cohort3 is PracticeData[2]
            var minValue = PracticeData[2].Students.Min(s => s.Birthday);
            //Assert.AreEqual(minValue, new DateTime(1972, 11, 14));
            Assert.AreEqual(minValue, new DateTime(1972, 11, 14));
        }

        [TestMethod]
        public void HowManyJuniorInstructorsAreThereInTheCohortWithTheMostJuniorInstructors()
        {
            //var maxValue = PracticeData/*FILL IN LINQ EXPRESSION*/;
            var maxValue = PracticeData.Max(c => c.JuniorInstructors.Count());
            //Assert.AreEqual(maxValue, 3);
            Assert.AreEqual(maxValue, 3);
        }
    }
}

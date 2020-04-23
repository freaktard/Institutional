using Institution.Controllers;
using Institution.Interffaces;
using Institution.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentsUnitTests.Stubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StudentsUnitTests.Controllers
{
    [TestClass]
    class StudentControllerTest
    {
        private StubStudent stubStudentRe;
        private StudentControllerTest controller;

        [TestInitialize]
        public void Setup()
        {

            stubStudentRe = new StubStudent();
            controller = new StudentsControllerTest(stubStudentRe);

        }

        [TestMethod]
        public void CreateStudentInsertStudent()
        {
            //ARRANGE
            bool insertOrUpdatecalled = false;
            bool savedCalled = false;

            stubStudentRe.Save = () => savedCalled = true;
            stubStudentRe.InsertOrUpdate = (Student) =>
              {
                  insertOrUpdatecalled = true;
                  Student.STUDENT_ID = 1;
              };

            //ACT
            Student newStudent = new Student();
            controller.Create(newStudent);

            //ASSERT
            Assert.IsTrue(newStudent.STUDENT_ID > 0);
            Assert.IsTrue(insertOrUpdatecalled);
            Assert.IsTrue(savedCalled);
        }
    }
}

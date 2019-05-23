using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Models;

namespace UnitTestProject
{
    [TestClass]
    class LoginPageUnitTest
    {
        private EmployeeCollection employeeCollection;

        public EmployeeCollection GetTestEmployeeCollection()
        {
            return new EmployeeCollection();
        }

        [TestMethod] //#1
        private void TestCorrectLogin()
        {
            //Arrange
            GetTestEmployeeCollection().Employees = new Dictionary<int, Employee>();

            //Act
            bool correctLoginResult = employeeCollection.RequestLogin("Daniel", 12345);

            //Assert
            Assert.IsTrue(correctLoginResult);
        }
        [TestMethod] //#2
        private void TestFalseLogin()
        {
            //Arrange

            //Act

            //Assert
        }
        [TestMethod] //#3
        private void TestNullInput()
        {
            //Arrange

            //Act
            bool NullResult = employeeCollection.RequestLogin("", int.Parse(""));

            //Assert
            Assert.IsNull(NullResult);
        }
        [TestMethod] //#4
        private void TestNotLogin()
        {
            //Arrange
            GetTestEmployeeCollection().Employees = new Dictionary<int, Employee>();
            //Act
            bool notLoginResult = employeeCollection.RequestLogin("Mohammed", 12345);
            //Assert
            Assert.IsFalse(notLoginResult);
        }
        [TestMethod] //#5
        private void TestUppercaseLetter()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod] //#6
        private void TestLowercaseLetter()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod] //#7
        private void TestPasswordLetters()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod] //#8
        private void TestUsernameNumbers()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}

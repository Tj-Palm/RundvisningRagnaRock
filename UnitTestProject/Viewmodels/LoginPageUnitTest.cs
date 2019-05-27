using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Models;

namespace UnitTestProject
{
    [TestClass]
    public class LoginPageUnitTest
    {
        private EmployeeCollection employeeCollection;

        public void Arrange()
        {
            employeeCollection = new EmployeeCollection();
        }

        public EmployeeCollection GetTestEmployeeCollection()
        {
            return new EmployeeCollection();
        }

        [TestMethod] //#1
        public void TestCorrectLogin()
        {
            //Arrange
            Arrange();

            //Act
            bool correctLoginResult = GetTestEmployeeCollection().RequestLogin("Daniel", 12345);

            //Assert
            Assert.IsTrue(correctLoginResult);
        }
        [TestMethod] //#2
        public void TestNullInput()
        {
            //Arrange
            Arrange();
            //Act
            bool NullResult = GetTestEmployeeCollection().RequestLogin("", int.Parse(""));

            //Assert
            Assert.IsNull(NullResult);
        }
        [TestMethod] //#3
        public void TestNotLogin()
        {
            //Arrange
            Arrange();

            //Act
            bool notLoginResult = GetTestEmployeeCollection().RequestLogin("Mohammed", 12345);
            //Assert
            Assert.IsFalse(notLoginResult);
        }
        [TestMethod] //#4
        public void TestUppercaseLetter()
        {
            //Arrange

            //Act

            //Assert
        }

        [TestMethod] //#5
        public void TestLowercaseLetter()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod] //#6
        public void TestPasswordLetters()
        {
            //Arrange

            //Act

            //Assert

        }

        [TestMethod] //#9
        public void TestUsernameNumbers()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}

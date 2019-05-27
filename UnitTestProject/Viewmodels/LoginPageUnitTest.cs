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
        public void TestNotLogin()
        {
            //Arrange
            Arrange();

            //Act
            bool notLoginResult = GetTestEmployeeCollection().RequestLogin("Mohammed", 12345);
            //Assert
            Assert.IsFalse(notLoginResult);
        }

        [TestMethod] //#3
        public void TestNoInputUsername()
        {
            //Arrange
            Arrange();
            //Act
            bool noInputUsername = GetTestEmployeeCollection().RequestLogin("", 1);
            //Assert
            Assert.IsFalse(noInputUsername);
        }

        [TestMethod] //#4
        public void TestUppercaseLetter()
        {
            //Arrange
            Arrange();
            //Act
            bool isUpperCaseLetter = GetTestEmployeeCollection().RequestLogin("Daniel", 123);
            //Assert
        }

        [TestMethod] //#4
        public void TestLowercaseLetter()
        {
            //Arrange
            Arrange();
            //Act
            bool isLowerCaseLetter = GetTestEmployeeCollection().RequestLogin("daniel", 123);
            //Assert

        }

        [TestMethod] //#5
        public void TestPasswordLetters()
        {
            //Arrange
            Arrange();
            //Act
            bool isPasswordLetters = GetTestEmployeeCollection().RequestLogin("Daniel", int.Parse("Daniel"));
            //Assert

        }

        [TestMethod] //#6
        public void TestUsernameNumbers()
        {
            ////Arrange
            //Arrange();
            ////Act
            //bool isUsernameNumbers = GetTestEmployeeCollection().RequestLogin(string. 123, 12345);
            //Assert
        }
    }
}

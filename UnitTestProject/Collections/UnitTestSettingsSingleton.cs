using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestSettingsSingleton
    {
        private SettingsSingleton settingsSingleton;
        private TextChanger testTextChanger;

        public void Arrange()
        {
            settingsSingleton = SettingsSingleton.Instance;
        }

        public AudioController GetTestAudioController()
        {
            return new AudioController();
        }

        public TextChanger GetTestTextChanger()
        {
            return new TextChanger();
        }


        [TestMethod]
        public void TestSaveToFile()
        {
            //Arrange
            Arrange();
            double startvalue = testTextChanger.textSize;
            TextChanger item = GetTestTextChanger();
            
            //Act
            double d = testTextChanger.textSize + 1;
            settingsSingleton.SaveAsync();
            settingsSingleton.LoadTextAsync();

            //Assert
            Assert.AreEqual(startvalue + 1, testTextChanger.textSize);
        }

    }
}

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RundvisningRagnaRock.Annotations;
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
            testTextChanger = new TextChanger();
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
            double startValue = testTextChanger.textSize;
            TextChanger item = GetTestTextChanger();
            
            //Act
            double d = testTextChanger.textSize + 1;
            testTextChanger.textSize = d;
            settingsSingleton.SaveAsync();
            settingsSingleton.LoadTextAsync();

            //Assert
            Assert.AreEqual(startValue + 1, testTextChanger.textSize);
        }
        
        public void TestToLoadFile()
        {
            //Arrange
            Arrange();
            double startValue = testTextChanger.textSize;
            TextChanger item = GetTestTextChanger();

            //Act
            double d = testTextChanger.textSize - 1;
            testTextChanger.textSize = d;
            settingsSingleton.LoadTextAsync();

            //Assert
            Assert.AreEqual(startValue - 1, testTextChanger.textSize);
        }

    }
}

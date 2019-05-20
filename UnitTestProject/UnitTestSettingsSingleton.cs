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

    }
}

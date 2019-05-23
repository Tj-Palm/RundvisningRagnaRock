using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RundvisningRagnaRock.ViewModels;

namespace UnitTestProject.Viewmodels
{
    [TestClass]
    public class CreateViewUnitTest
    {
        private CreateViewModel createViewModel;
        public void Arrange()
        {
            createViewModel = new CreateViewModel();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Models;
using RundvisningRagnaRock.ViewModels;

namespace UnitTestProject.Viewmodels
{
    [TestClass]
    public class CreateViewUnitTest
    {
        private CreateViewModel createViewModel;
        private LocationCollection _locationcol;

        public void Arrange()
        {
            createViewModel = new CreateViewModel();
        }

        public UDS GetTestUDS()
        {
            return new UDS("name", CategoriesCollection.Instance.Categories[0],createViewModel.Locations[0],"desc","pic","sound");
        }

        [TestMethod]
        public async void Testadd()
        {
            //Arrange
            Arrange();
            int startvalue = UdsCollection.Instance.UDScollection.Count;
            UDS item = GetTestUDS();

            //Act
            UdsCollection.Instance.Add(item);

            //Assert
            Assert.AreEqual(startvalue + 1, UdsCollection.Instance.UDScollection.Count);

            //Cleanup
            UdsCollection.Instance.UDScollection.Remove(item);
        }
    }
}

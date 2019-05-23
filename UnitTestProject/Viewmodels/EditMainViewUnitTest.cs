using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RundvisningRagnaRock.ViewModels;
using RundvisningRagnaRock.Models;

namespace UnitTestProject
{
     [TestClass]
    public class EditMainViewUnitTest
    {
        private EditViewModel editViewModel;

        private void Arrage()
        {
            editViewModel = new EditViewModel();
        }

        [TestMethod]
        public void TestGetCategories()
        {
            //Arrange
            Arrage();

            //Act
            ObservableCollection<Category> categories = editViewModel.Categories;

            //Assert
            Assert.IsTrue(categories != null); 
        }

        [TestMethod]
        public void TestGetLocation()
        {
            //Arrange
            Arrage();

            //Act
            ObservableCollection<Location> location = editViewModel.Locations;

            //Assert
            Assert.IsTrue(location != null);

        }

        [TestMethod]
        public void TestGetSelectedLocation()
        {
            //Arrange
            Arrage();
            bool locationLoadingSuccessfull = false;
            


            //Act
            int count = 0;
            int waittime = 10;

            while (count < waittime)
            {
                if (editViewModel.Locations.Count > 0)
                {
                    locationLoadingSuccessfull = true;
                    count = waittime;

                }
                else
                {
                    Task.Delay(1000);
                }
           

                count++;
            }

            if (locationLoadingSuccessfull)
            {
                //TODO Spørg Muhammed: Can't run StorageFolder in debug!!!

                ObservableCollection<Location> locations = editViewModel.Locations;
                editViewModel.SelectedLocation = locations[0];
            }

            //Assert

            if (locationLoadingSuccessfull)
            {
                Assert.AreEqual(editViewModel.SelectedLocation, editViewModel.Locations[0]);
            }
            else
            {
                Assert.Fail("Loading locations failed");
            }
        }

        [TestMethod]
        public void TestGetSelectedCategory()
        {
            //Arrange
            Arrage();

            //Act
            ObservableCollection<Category> categories = editViewModel.Categories;

            editViewModel.SelectedCategory = categories[0];

            //Assert
            Assert.AreEqual(editViewModel.SelectedCategory, editViewModel.Categories[0]);
        }

        [TestMethod]
        public void TestGetUdstillingsgenstande()
        {
            //Arrange
            Arrage();

            //Act
            ObservableCollection<UDS> uds = editViewModel.UdstillingsGenstande;

            //Assert
            Assert.IsTrue(uds != null);
        }

    }
}


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Models;

namespace UnitTestProject
{
    [TestClass]
    public class UDSCollectionUnitTest
    {

       private UdsCollection collection;

        public void Arrange()
        {
            collection = UdsCollection.Instance;
        }

        public UDS GetTestUDS()
        {
            return new UDS("test", CategoriesCollection.Instance.Categories[0], "tests", "test", "test", "test");
        }

        [TestMethod]
        public void TestAdd()
        {
           //Arrange
            Arrange();
            int startvalue =  collection.UDScollection.Count;
            UDS item = GetTestUDS();

            //Act
            collection.UDScollection.Add(item);
            
           //Assert
           Assert.AreEqual(startvalue +1 , collection.UDScollection.Count);

           //Cleanup
           collection.UDScollection.Remove(item);
        }

        [TestMethod]
        public void TestRemove()
        {
            //Arrange
            Arrange();
            
            UDS item = GetTestUDS();
            collection.UDScollection.Add(item);
            int startvalue = collection.UDScollection.Count;
            //Act
            collection.UDScollection.Remove(item);

            //Assert
            Assert.AreEqual(startvalue - 1, collection.UDScollection.Count);         
        }
    }
}

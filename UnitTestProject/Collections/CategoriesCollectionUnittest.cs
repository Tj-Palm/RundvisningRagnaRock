using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Models;

namespace UnitTestProject
{
    [TestClass]
    public class CategoriesCollectionUnittest
    {
 
        private CategoriesCollection categoriesCollection;

        public void Arrange()
        {
            categoriesCollection = CategoriesCollection.Instance;
        }

        public Category GetTestCategory()
        {
            return new Category("test", "test");
        }

        [TestMethod]
        public void TestAdd()
        {
            //Arrange
            Arrange();
            int startvalue = categoriesCollection.Categories.Count;
            Category item = GetTestCategory();

            //Act
            categoriesCollection.AddCategory(GetTestCategory().Name,GetTestCategory().Icon);

            //Assert
            Assert.AreEqual(startvalue + 1,categoriesCollection.Categories.Count);

            //Cleanup
            categoriesCollection.Categories.Remove(item);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{
   public class CategoriesCollection
    {

        #region Singleton
        private static CategoriesCollection _instance;

        public static CategoriesCollection Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CategoriesCollection();
                    return _instance;
                }

                return _instance;
            }
        }
        #endregion

        private CategoriesCollection()
        {

         _categoryCollection = new Dictionary<int, Category>();

         //TODO for testing. testdata



        }

        private Dictionary<int,Category> _categoryCollection;

        public List<Category> Categories
        {
            get
            {
                return _categoryCollection.Values.ToList();
            } 
        }

        public void AddCategory(string name, string icon)
        {
            if (name != null && icon != null)
            {   
                Category newCat = new Category(name, icon);

                _categoryCollection.Add(newCat.ID, newCat);         
            }
            else
            {
                throw new ArgumentException("Missing name or icon");
            }
        }



    }
}

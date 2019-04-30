using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{
    class CategoriesCollection
    {
        private Dictionary<int,Category> _categoryCollection;

        public Dictionary<int,Category> Categories
        {
            get { return _categoryCollection; } 
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

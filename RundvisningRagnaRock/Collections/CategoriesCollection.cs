using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{

    /// <summary>
    /// En collection af kategorier.
    /// </summary>
   public class CategoriesCollection
    {
        /// <summary>
        /// En dictionary som indeholder kategorier.
        /// key er en int id.
        /// </summary>
        private Dictionary<int, Category> _categoryCollection;


        #region Singleton

        /// <summary>
        /// singleton inplemantation
        /// </summary>
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

        #region Constructor

        /// <summary>
        /// constructor som initialisere en dictionry
        /// tilføjer test data.
        /// </summary>
        private CategoriesCollection()
        {

         _categoryCollection = new Dictionary<int, Category>();

            //TODO for testing. testdata
            AddCategory("Gramofon", "../Assets/Gramofon.jpg");
            AddCategory("Guitar", "../Assets/Guitar.png");
            AddCategory("Heart", "../Assets/Heart.png");
            AddCategory("Rock", "../Assets/Rock.jpg");

        }
        #endregion

        #region Properties

        /// <summary>
        /// Retunere en liste af Categories
        /// </summary>

        
        public List<Category> Categories
        {
            get
            {
                return _categoryCollection.Values.ToList();
            } 
        }
        #endregion

        #region Methods    
        /// <summary>
        /// tilføjer en kategori til dictionary
        /// man skal angive 2 parametre.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="icon"></param>     

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

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
    /// <summary>
    /// UDS er en forkortelse af udstillingsgenstand
    /// UDS klassen indeholder infomaitoner on den enkelte udstillingsgenstand. 
    /// </summary>

    public class UDS
    {
        #region Instancefields
        private static int _idcount;

        private int _ID;
        private string _name;
        private Category _category;
        private Location _location;
        private string _desctiption;
        private string _pictureDirectory;
        private string _soundFileName;
        #endregion

        #region Constructor

        /// <summary>
        /// UDS constructoren har 6 parametre.
        /// name, category og location er obligatorist.
        /// description, pictureDirectory og soundFileDirectory er valgfri.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="category"></param>
        /// <param name="location"></param>
        /// <param name="desctiption"></param>
        /// <param name="pictureDirectory"></param>
        /// <param name="soundFileName"></param>

        public UDS( string name, Category category, Location location, string desctiption = null, string pictureDirectory = null, string soundFileDirectory = null)
        {
        
            
            if (name == null || category == null || location == null || name == "")
            {
                throw  new ArgumentException("Unstilling genstand skal have navn, categori og lokation");
            }

            _ID = _idcount + 1;
            _idcount++;
            
            _name = name;
            _category = category;
            _location = location;
            _desctiption = desctiption;
            _pictureDirectory = pictureDirectory;
            _soundFileName = soundFileDirectory;

        }

        #endregion

        #region Properties

        /// <summary>
        /// Den placering på computeren hvor lydfilen ligger.
        /// </summary>

        public string SoundFileName
        {
            get { return _soundFileName; }
            set { _soundFileName = value; }
        }


        /// <summary>
        /// Den placering på computeren hvor billede ligger.
        /// </summary>

        public string PictureDirectory
        {
            get { return _pictureDirectory; }
        }

        /// <summary>
        /// UDS beskrivelse.
        /// </summary>

         public virtual string Description
        {
            get { return _desctiption; }
            set { _desctiption = value; }
        }

        /// <summary>
        /// UDS lokation.
        /// </summary>

        public Location Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// UDS category
        /// </summary>

        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }

        /// <summary>
        /// UDS navn.
        /// </summary>

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// unikt UDS id.
        /// </summary>

        public int ID
        {
            get { return _ID; }
        }
        #endregion
    }
}

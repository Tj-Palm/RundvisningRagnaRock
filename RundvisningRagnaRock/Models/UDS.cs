using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
    public class UDS
    {
        #region Instancefields
        private static int _idcount;

        private int _ID;
        private string _name;
        private Category _category;
        private string _location;
        private string _desctiption;
        private string _pictureDirectory;
        private string _soundFileDirectory;
        #endregion

        #region Constructor

         public UDS( string name, Category category, string location, string desctiption, string pictureDirectory, string soundFileDirectory)
        {

            if (name == null || category == null || location == null || name == "" || location == "")
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
            _soundFileDirectory = soundFileDirectory;

        }

        #endregion

        #region Properties

   public string SoundFileDirectory
        {
            get { return _soundFileDirectory; }
            set { _soundFileDirectory = value; }
        }

        public string PictureDirectory
        {
            get { return _pictureDirectory; }
        }

        public string Description
        {
            get { return _desctiption; }
            set { _desctiption = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int ID
        {
            get { return _ID; }
        }
        #endregion
    }
}

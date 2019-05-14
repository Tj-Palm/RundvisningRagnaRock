using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
   public class Category
    {
        
        private static int _globalID = 999;

        #region Instance fields
        private int _id;
        private string _icon;
        private string _name;
        #endregion

        #region Constructor

        public Category(string name, string icon)
        {
            _id = _globalID;
            _globalID++;
            _name = name;
            _icon = icon;
        }

        #endregion

        #region Properties

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        #endregion
    }
}

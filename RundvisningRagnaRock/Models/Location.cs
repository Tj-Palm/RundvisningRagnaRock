using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
    class Location
    {
        private DynamicButton _dynamicButton;

        public DynamicButton DynamicButton
        {
            get { return _dynamicButton; }
            set { _dynamicButton = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



    }
}

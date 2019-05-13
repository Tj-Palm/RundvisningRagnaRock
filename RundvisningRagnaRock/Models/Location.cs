using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
    public class Location
    {
        public Location(DynamicButton dynamicButton, string name, string description, string iconPlacement)
        {
            _dynamicButton = dynamicButton;
            _name = name;
            _description = description;
            _iconPlacement = iconPlacement;
        }

        private DynamicButton _dynamicButton;
        private string _name;
        private string _description;

        public DynamicButton DynamicButton
        {
            get { return _dynamicButton; }
            set { _dynamicButton = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private string _iconPlacement;

        public string IconPlacement
        {
            get { return _iconPlacement; }
            set { _iconPlacement = value; }
        }

    }
}


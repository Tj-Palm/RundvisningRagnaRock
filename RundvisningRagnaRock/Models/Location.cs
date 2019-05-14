using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Enums;

namespace RundvisningRagnaRock.Models
{
    public class Location
    {
        private int _yCoordinate;
        private int _xCoordinate;
        private int _bheight;
        private int _bwidth;
        private Etage _etage;
        private string _name;
        private string _description;
        private string _icon;
        private static int _LastID;
        private int _id;

        public Location(int yCoordinate, int xCoordinate, int bheight, int bwidth, Etage etage, string name, string description, string icon)
        {
            _id = _LastID++;
            _LastID++;

            _yCoordinate = yCoordinate;
            _xCoordinate = xCoordinate;
            _bheight = bheight;
            _bwidth = bwidth;
            _etage = etage;
            _name = name;
            _description = description;
            _icon = icon;
        }

        

        public int Id
        {
            get { return _id; }
            set { _id = value; }
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

        public string Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        public Etage Etage
        {
            get { return _etage; }
            set { _etage = value; }
        }

        public int yCoordinate
        {
            get { return _yCoordinate; }
            set { _yCoordinate = value; }
        }

        public int xCoordinate
        {
            get { return _xCoordinate; }
            set { _xCoordinate = value; }
        }

        public int BHeight
        {
            get { return _bheight; }
            set { _bheight = value; }
        }

        public int BWidth
        {
            get { return _bwidth; }
            set { _bwidth = value; }
        }

    }
}


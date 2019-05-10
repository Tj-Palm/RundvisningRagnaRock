using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RundvisningRagnaRock.Models
{
    class DynamicButton
    {

        private int _yCoordinate;
        private int _xCoordinate;
        private int _bheight;
        private int _bwidth;

        public DynamicButton(int yCoordinate, int xCoordinate, int bheight, int bwidth, Category category)
        {
            _yCoordinate = yCoordinate;
            _xCoordinate = xCoordinate;
            _bheight = bheight;
            _bwidth = bwidth;
            _category = category;
        }

        private Category _category;

        public Category Category
        {
            get { return _category; }
            set { _category = value; }
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

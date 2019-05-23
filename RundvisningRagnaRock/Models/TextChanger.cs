using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
    public class TextChanger
    {
        
        private double _textsize;
        private const double _maxsize = 50;
        private const double _minsize = 10;

        public TextChanger()
        {
            textSize = 10;
        }

        public double textSize
        {
            get {  return _textsize; }
            set {_textsize = value; }
        }

        public double MaxSize
        {
            get { return _maxsize; }
        }

        public double MinSize
        {
            get { return _minsize; }
        }
        
    }
}

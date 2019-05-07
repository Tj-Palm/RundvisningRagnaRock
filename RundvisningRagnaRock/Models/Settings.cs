using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
    class Settings
    {
        private int _soundvolume;
        private int _textsize;

        public int soundVolume
        {
            get { return _soundvolume; }
            set { _soundvolume = value; }
        }

        public int textSize
        {
            get { return _textsize; }
            set { _textsize = value; }
        }
    }
}

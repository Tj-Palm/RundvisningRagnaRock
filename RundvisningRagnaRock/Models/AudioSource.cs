using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
    class AudioSource
    {
        private double _soundvolume;
        public double Volume
        {
            get { return _soundvolume; }
            set { _soundvolume = value; }
        } 
    }
}

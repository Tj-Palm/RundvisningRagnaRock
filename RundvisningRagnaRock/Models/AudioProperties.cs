using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RundvisningRagnaRock.Models
{
    public class AudioProperties 
    {
        private const double _minvolume = 0;
        private const double _maxvolume = 100;
        private double _volume;

        public double Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        public double MaxVolume
        {
            get { return _maxvolume; }
        }

        public double MinVolume
        {
            get { return _minvolume; }
        }

    }
}

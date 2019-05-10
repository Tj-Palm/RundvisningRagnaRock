using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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

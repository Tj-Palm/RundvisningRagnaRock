using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;

namespace RundvisningRagnaRock.Models
{
    class AudioSource
    {
        private double _soundvolume;
        private readonly string musictest = "../Assets/Music/MusicTest.mp3";
        
        public double Volume
        {
            get { return _soundvolume; }
            set { _soundvolume = value; }
        }

        public AudioSource()
        {
            MediaPlayer player = new MediaPlayer();
            player.Source = player.SetMediaSource(musictest);


        }
    }
}

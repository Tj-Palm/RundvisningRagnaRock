using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.UI.Xaml.Controls;

namespace RundvisningRagnaRock.Models
{
    class Settings
    {
        public Slider SoundVolume;
        public AudioSource myMusic;

        //Update is called once per frame.
        void UpdateMusic()
        {
            myMusic.Volume = SoundVolume.Value;
        }

        public Slider Textresizer;
        public TextChanger myText;

        //Update is called once per frame.
        void UpdateText()
        {
            myText.textSize = Textresizer.Value;
        }

        MediaPlayer player = new MediaPlayer();
        
        
    }

}

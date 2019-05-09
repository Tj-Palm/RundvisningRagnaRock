using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace RundvisningRagnaRock.Models
{
    class Settings
    {
        //private int _soundvolume;
        //private int _textsize;

        //public int soundVolume
        //{
        //    get { return _soundvolume; }
        //    set { _soundvolume = value; }
        //}

        //public int textSize
        //{
        //    get { return _textsize; }
        //    set { _textsize = value; }
        //}

        public Slider SoundVolume;
        public AudioSource myMusic;

        void UpdateMusic()
        {
            myMusic.Volume = SoundVolume.Value;
        }

        public Slider Textresizer;
        public TextChanger myText;

        void UpdateText()
        {
            myText.textSize = Textresizer.Value;
        }
    }

}

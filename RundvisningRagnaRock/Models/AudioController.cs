using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WinRTXamlToolkit.Controls;
using WinRTXamlToolkit.IO.Extensions;

namespace RundvisningRagnaRock.Models
{
    public partial class AudioController
    {
        #region MediaElement

        public MediaElement MyMusic = new MediaElement();

        #endregion
 
        #region Constructor
        public AudioController()
        {
            //SetSound();
        }
        #endregion
        
        #region Properties
        public AudioProperties Properties
        {
            get { return new AudioProperties();}
        }

        public double MaxVolumeControl
        {
            get { return Properties.MaxVolume; }
        }

        public double MinVolumeControl
        {
            get { return Properties.MinVolume; }
        }

        public void SetVolume(double volume)
        {
            MyMusic.Volume = volume;
            Properties.Volume = volume;
        }

        #endregion

        #region Methods
        public async void SetSound(string mp3)
        {
            if (mp3 != null)
            {
                StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;

                Folder = await Folder.GetFolderAsync("Assets");
                bool containsFile = await Folder.ContainsFileAsync(mp3);

                if (containsFile)
                {
                    StorageFile sf = await Folder.GetFileAsync(mp3);
                    MyMusic.AutoPlay = false;
                    MyMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);
                }
            }
        }

        public async void PlayAudio()
        {
                MyMusic.Play();   
        }

        public void PauseAudio()
        {
                if (MyMusic.CanPause)
                {
                   MyMusic.Pause();
                }
        }

        public void MuteAudio()
        {
            MyMusic.IsMuted = !MyMusic.IsMuted;
           
        }

        public static implicit operator AudioController(AudioProperties v)
        {
            throw new NotImplementedException();
        }

        //public void TurnUpVolume()
        //{
        //    MyMusic.Volume += 0.01;
        //}

        //public void TurnDownVolume()
        //{
        //    MyMusic.Volume -= 0.01;
        //}

        #endregion
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace RundvisningRagnaRock.Models
{
    class AudioController
    {
        private double _soundvolume;

        MediaElement PlayMusic = new MediaElement();

        public AudioController()
        {
            AudioControl();
        }

        public double Volume
        {
            get { return _soundvolume; }
            set { _soundvolume = value; }
        }

        public async void AudioControl()
        {
            StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Folder = await Folder.GetFolderAsync("Assets");
            StorageFile sf = await Folder.GetFileAsync("MusicTest.mp3");
            PlayMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);
        }

        public void PlayAudio()
        {
            PlayMusic.Play();
        }

        public void PauseAudio()
        {
            PlayMusic.Pause();
        }
        
        public void MuteAudio()
        {
            PlayMusic.IsMuted = true;
        }
    }
}

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
        private const double _minvolume = 0;
        private const double _maxvolume = 10;

        MediaElement MyMusic = new MediaElement();

        //public AudioController()
        //{
        //    AudioControl();
        //}

        public double Volume
        {
            get { return MyMusic.Volume; }
            set { MyMusic.Volume = value; }
        }

        public double MaxVolume
        {
            get { return _maxvolume; }
        }

        public double MinVolume
        {
            get {return _minvolume;}
        }

        //public async void AudioControl()
        //{
        //    StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
        //    Folder = await Folder.GetFolderAsync("Assets");
        //    StorageFile sf = await Folder.GetFileAsync("MusicTest.mp3");
        //    MyMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);
        //}

        //public void SetVolume(double volume)
        //{
        //    MyMusic.Volume = volume;
        //}

        public async void PlayAudio()
        {
            StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Folder = await Folder.GetFolderAsync("Assets");
            StorageFile sf = await Folder.GetFileAsync("MusicTest.mp3");
            MyMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);
            MyMusic.Play();
        }

        public void PauseAudio()
        {
            MyMusic.Pause();
        }
        
        public void MuteAudio()
        {
            MyMusic.IsMuted = true;
        }
    }
}

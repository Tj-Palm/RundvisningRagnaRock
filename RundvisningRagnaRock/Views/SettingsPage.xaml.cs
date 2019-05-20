using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RundvisningRagnaRock.Models;
using WinRTXamlToolkit.Controls;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RundvisningRagnaRock.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public partial class Form : Page
    {
        MediaElement myMediaElement = new MediaElement();

        public Form()
        {
            this.InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }


        MediaElement PlayMusic = new MediaElement();


        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            Folder = await Folder.GetFolderAsync("Assets");
            StorageFile sf = await Folder.GetFileAsync("TestMusic.mp3");
            PlayMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);
            PlayMusic.Play();
        }

        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PlayMusic.Pause();
        }

        private async void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PlayMusic.IsMuted = true;
        }

        private void ChangeMediaVolume(object sender, RangeBaseValueChangedEventArgs rangeBaseValueChangedEventArgs)
        {
            PlayMusic.Volume = (double)volumeSlider.Value;
        }
    }

}

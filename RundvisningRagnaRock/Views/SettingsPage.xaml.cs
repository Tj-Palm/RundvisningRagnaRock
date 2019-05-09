using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RundvisningRagnaRock.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RundvisningRagnaRock.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        MediaPlayer player = new MediaPlayer();
        
        public SettingsPage()
        {
            this.InitializeComponent();
        }
        //public void Audio()
        //{
        //   player.Source = mediasource.
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            player.Play();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            player.IsMuted = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Common;
using RundvisningRagnaRock.Models;
using RundvisningRagnaRock.Views;

namespace RundvisningRagnaRock.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        AudioController MyController = new AudioController();
        TextChanger MyTextChanger = new TextChanger();


        public SettingsViewModel()
        {

            SaveCommand = new RelayCommand(ToSaveCommand);
            PlayCommand = new RelayCommand(ToPlayCommand);
            PauseCommand = new RelayCommand(ToPauseCommand);
            MuteCommand = new RelayCommand(ToMuteCommand);
            //VolUp = new RelayCommand(VolUpCommand);
            //VolDown = new RelayCommand(VolDownCommand);
           
            //Load();
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand PlayCommand { get; set; }
        public RelayCommand PauseCommand { get; set; }
        public RelayCommand MuteCommand { get; set; }
        //public RelayCommand VolUp { get; set; }
        //public RelayCommand VolDown { get; set; }


        public double Volume
        {
           get {return MyController.Volume;}
           set { MyController.Volume = value; OnPropertyChanged();}
        }

        public double MaxSize
        {
            get { return MyTextChanger.MaxSize; }
        }

        public double MinSize
        {
            get { return MyTextChanger.MinSize; }
        }

        public double MaxVolume
        {
            get { return MyController.MaxVolume; }
        }

        public double MinVolume
        {
            get { return MyController.MinVolume; }
        }

        public async void ToSaveCommand()
        {
            await SettingsSingleton.SaveAsync();
        }

        private async void Load()
        {
            await SettingsSingleton.LoadAsync<Settings>();
        }

        public void ToPlayCommand()
        {
           MyController.PlayAudio();
        }

        public void ToPauseCommand()
        {
            MyController.PauseAudio();
        }

        public void ToMuteCommand()
        {
            MyController.MuteAudio();
        }

        //public void VolUpCommand()
        //{
        //    MyController.VolUp();
        //}
        //public void VolDownCommand()
        //{
        //    MyController.VolDown();
        //}
    }
}

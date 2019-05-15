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
            VolUp = new RelayCommand(VolUpCommand);
            VolDown = new RelayCommand(VolDownCommand);

            //Load();
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand PlayCommand { get; set; }
        public RelayCommand PauseCommand { get; set; }
        public RelayCommand MuteCommand { get; set; }
        public RelayCommand VolUp { get; set; }
        public RelayCommand VolDown { get; set; }


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
            await SettingsSingleton.Instance.SaveAsync();
        }

        private async void LoadAudioAsync()
        {
           MyController = await SettingsSingleton.Instance.LoadAudioAsync();
        }

        private async void LoadTextAsync()
        {
            MyTextChanger = await SettingsSingleton.Instance.LoadTextAsync();
        }

        public void ToPlayCommand()
        {
           MyController.PlayAudio();
        }

        public void ToPauseCommand()
        {
            MyController.PauseAudio();

            //MyController.Volume = 0.7;

        }

        public void ToMuteCommand()
        {
            //MyController.Volume = 0.2;

            MyController.MuteAudio();
        }

        public void VolUpCommand()
        {
            MyController.TurnUpVolume();
        }
        public void VolDownCommand()
        {
            MyController.TurnDownVolume();
        }
    }
}

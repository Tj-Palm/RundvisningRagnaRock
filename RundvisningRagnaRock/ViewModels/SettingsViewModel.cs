using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binding_MVVM.Persistency;
using Newtonsoft.Json.Linq;
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
            //VolUp = new RelayCommand(VolUpCommand);
            //VolDown = new RelayCommand(VolDownCommand);
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand VolUp { get; set; }
        public RelayCommand VolDown { get; set; }


        public string JsonFolder
        {
            get { return SettingsSingleton.Instance.Folder; }
          
        }


        public double TextValue
        {
            get { return MyTextChanger.textSize;}
            set { MyTextChanger.textSize = value; OnPropertyChanged();} 
        }

        public double Volume
        {
           get {return MyController.Properties.Volume;}
           set { MyController.Properties.Volume = value; OnPropertyChanged();}
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
            get { return MyController.MaxVolumeControl; }
        }

        public double MinVolume
        {
            get { return MyController.MinVolumeControl; }
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

        //public void VolUpCommand()
        //{
        //    MyController.TurnUpVolume();
        //}
        //public void VolDownCommand()
        //{
        //    MyController.TurnDownVolume();
        //}
    }
}

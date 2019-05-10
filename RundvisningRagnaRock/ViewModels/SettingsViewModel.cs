using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Common;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.ViewModels
{
    public class SettingsViewModel
    {
        AudioController MyController = new AudioController();

        public SettingsViewModel()
        {

            SaveCommand = new RelayCommand(ToSaveCommand);
            PlayCommand = new RelayCommand(ToPlayCommand);
            PauseCommand = new RelayCommand(ToPauseCommand);
            MuteCommand = new RelayCommand(ToMuteCommand);
            //Load();
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand PlayCommand { get; set; }
        public RelayCommand PauseCommand { get; set; }
        public RelayCommand MuteCommand { get; set; }



        public async void ToSaveCommand()
        {
            await SettingsSingleton.SaveAsync();
        }

        //private async void Load()
        //{
        //    await SettingsSingleton.LoadAsync<Settings>();
        //}

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
    }
}

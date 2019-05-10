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
        
        public SettingsViewModel()
        {
            SaveCommand = new RelayCommand(ToSaveCommand);
            Load();
        }

        public RelayCommand SaveCommand { get; set; }

        public async void ToSaveCommand()
        {
           await SettingsSingleton.SaveAsync();
        }

        private async void  Load()
        {
          await SettingsSingleton.LoadAsync<Settings>();
        }
    }
}

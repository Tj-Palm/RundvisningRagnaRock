using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Common;

namespace RundvisningRagnaRock.ViewModels
{
    class SettingsViewModel
    {
        
        public SettingsViewModel()
        {
            SaveCommand = new RelayCommand(ToSaveCommand);
            Load();
        }

        public RelayCommand SaveCommand { get; set; }

        public void ToSaveCommand()
        {
            SettingsSingleton.;
        }

        private void Load()
        {
            SettingsSingleton.LoadAsync();
        }
    }
}

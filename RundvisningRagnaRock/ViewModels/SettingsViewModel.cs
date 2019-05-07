using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Common;

namespace RundvisningRagnaRock.ViewModels
{
    class SettingsViewModel
    {
        public SettingsViewModel()
        {
            SaveCommand = new RelayCommand(toSaveCommand);
        }

        public RelayCommand SaveCommand { get; set; }

        public void toSaveCommand()
        {

        }
    }
}

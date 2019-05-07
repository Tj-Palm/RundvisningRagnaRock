using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Binding_MVVM.Persistency;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{
    class SettingsSingleton
    {
        private static SettingsSingleton _instance;
        private FilePersistency<Settings> _fileSource;
        private Settings _settings;

        public SettingsSingleton()
        {
            _fileSource = new FilePersistency<Settings>();
            _settings = new Settings();
        }


        public static SettingsSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SettingsSingleton();
                    return _instance;
                }
                else
                {
                    return _instance;
                }
            }
        }

        public async Task SaveAsync()
        {
            await _fileSource.SaveAsync(_settings);
        }

        public async Task LoadAsync()
        {
            _settings = _fileSource.LoadAsync();
        }

    }
}

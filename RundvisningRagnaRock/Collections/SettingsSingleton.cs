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
        private static FilePersistency<Settings> _fileSource;
        private static Settings _settings;

        public SettingsSingleton()
        {
            _fileSource = new FilePersistency<Settings>("Settings");
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

        public static async Task SaveAsync()
        {
            await _fileSource.SaveAsync(_settings);
        }

        public static async Task<Settings> LoadAsync<T>()
        {
            _settings = await _fileSource.LoadModelAsync();
            return _settings;
        }

    }
}

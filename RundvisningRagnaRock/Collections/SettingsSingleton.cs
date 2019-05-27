using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Binding_MVVM.Persistency;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{
    public class SettingsSingleton
    {
        #region Instancefields
        private static SettingsSingleton _instance;
        private static FilePersistency<AudioProperties> _fileSourceAudio;
        private static AudioProperties _audioProperties;
        private static FilePersistency<TextChanger> _fileSourceText;
        private static TextChanger _textChange;
        public Slider SoundVolume;
        public AudioController myMusic;
        public Slider Textresizer;
        public TextChanger myText;
        #endregion

        #region Constructor
          public SettingsSingleton()
          {
            _fileSourceAudio = new FilePersistency<AudioProperties>("AudioSource");
            _audioProperties = new AudioProperties();
            _fileSourceText = new FilePersistency<TextChanger>("TextSource");
            _textChange = new TextChanger();

            _folder = _fileSourceAudio.Folder.Path;
          }
        #endregion

        #region Singleton
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
        #endregion

        #region Methods
           //Update is called once per frame.
        void UpdateMusic()
        {
            myMusic.Properties.Volume = SoundVolume.Value;
        }

        public string folder { get; set; }

        private string _folder;

        public string Folder
        {
            get { return _folder; }
            set { _folder = value; }
        }


        //Update is called once per frame.
        void UpdateText()
        {
            myText.textSize = Textresizer.Value;
        }

        public async Task SaveAsync()
        {
            await _fileSourceAudio.SaveAsync(_audioProperties);
            await _fileSourceText.SaveAsync(_textChange);
        }

        public async Task<AudioProperties> LoadAudioAsync()
        {
            _audioProperties = await _fileSourceAudio.LoadModelAsync();
            return _audioProperties;
        }

        public async Task<TextChanger> LoadTextAsync()
        {
            _textChange = await _fileSourceText.LoadModelAsync();
            return _textChange;
        }
        #endregion

    }
}

﻿using System;
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
        private static FilePersistency<AudioController> _fileSourceAudio;
        private static AudioController _audioControl;
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
            _fileSourceAudio = new FilePersistency<AudioController>("AudioSource");
            _audioControl = new AudioController();
            _fileSourceText = new FilePersistency<TextChanger>("TextSource");
            _textChange = new TextChanger();
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
            myMusic.Volume = SoundVolume.Value;
        }

        //Update is called once per frame.
        void UpdateText()
        {
            myText.textSize = Textresizer.Value;
        }

        public async Task SaveAsync()
        {
            await _fileSourceAudio.SaveAsync(_audioControl);
            await _fileSourceText.SaveAsync(_textChange);
        }

        public async Task<AudioController> LoadAudioAsync()
        {
            _audioControl = await _fileSourceAudio.LoadModelAsync();
            return _audioControl;
        }

        public async Task<TextChanger> LoadTextAsync()
        {
            _textChange = await _fileSourceText.LoadModelAsync();
            return _textChange;
        }
        #endregion

    }
}

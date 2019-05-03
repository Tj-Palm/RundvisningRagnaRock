using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text.Core;
using RundvisningRagnaRock.Annotations;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Common;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.ViewModels
{
    public class GUICreateViewModel : INotifyPropertyChanged
    {
        private CategoriesCollection _category;
        private string _name;
        private Category _categoryProp;
        private string _location;
        private string _desctiption;
        private string _pictureDirectory;
        private string _soundFileDirectory;
        private string _messages;
        private bool _isAddButtonEnabled = true;

        public GUICreateViewModel()
        {
            _category = CategoriesCollection.Instance;
            AddCommand = new RelayCommand(ToAddUds);
        }

        public RelayCommand AddCommand { get; set; }

        public string SoundFileDirectory
        {
            get { return _soundFileDirectory; }
            set { _soundFileDirectory = value; }
        }

        public Category CategoryProp
        {
            get { return _categoryProp; }
            set
            {
                _categoryProp = value;
            }
        }

        public string PictureDirectory
        {
            get { return _pictureDirectory; }
            set { _pictureDirectory = value; }
        }

        public string Description
        {
            get { return _desctiption; }
            set { _desctiption = value; }
        }

        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }



        public bool IsAddButtonEnabled
        {
            get { return _isAddButtonEnabled; }
            set
            {
                _isAddButtonEnabled = value; 
                OnPropertyChanged();
            }
        }


        public async void ToAddUds()
        {
            bool result = false;
           
            Messages = "Opretter ny udstillings genstand";
            IsAddButtonEnabled = false;
            try
            {
                result = UdsCollection.Instance.Add(new UDS(Name, CategoryProp, Location, Description, PictureDirectory, SoundFileDirectory));

            }
            catch (Exception e)
            {
                result = false;
                Messages = e.Message;
            }
             
           await Task.Delay(2000);
           IsAddButtonEnabled = true;
            if (result)
           {
               Messages = $"{Name} er blevet oprettet";

              
           }
           else
           {
               {
                   Messages = $"fejlede at oprette {Name}";
                }
           }
           await Task.Delay(4000);
           
           Messages = "";

        }

        public ObservableCollection<Category> Category
        {
            get
            {
                ObservableCollection<Category> oCollection = new ObservableCollection<Category>();
                foreach (Category category in _category.Categories)
                {
                    oCollection.Add(category);
                }

                return oCollection;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

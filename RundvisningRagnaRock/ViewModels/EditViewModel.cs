using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Annotations;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Common;
using RundvisningRagnaRock.Models;
using RundvisningRagnaRock.Views;


namespace RundvisningRagnaRock.ViewModels
{
    public class EditViewModel : ViewModelBase
    {

        #region Instance fields

        private CategoriesCollection _categories;
        private UdsCollection _udstillingsGenstande;
        private UDS _selectedUdstillingsGenstand;
        private Category _selectedCategory;
        #endregion

        #region Constructor

        public EditViewModel()
        {
            _categories = CategoriesCollection.Instance;
            _udstillingsGenstande = UdsCollection.Instance;

            SaveCommand = new RelayCommand(toSaveCommand);
            DeleteCommand = new RelayCommand(toDeleteCommand);
        }
        #endregion

        #region Properties

        public ObservableCollection<UDS> UdstillingsGenstande
        {
            get
            {
                ObservableCollection<UDS> collection = new ObservableCollection<UDS>(_udstillingsGenstande.UDScollection);
                return collection;
            }

        }

        public Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
               
                _selectedCategory = value;
                _selectedUdstillingsGenstand.Category = value;
                OnPropertyChanged(nameof(UdstillingsGenstande));
            }
        }

        public ObservableCollection<Category> Categories
        {
            get
            {
                ObservableCollection<Category> categories = new ObservableCollection<Category>(this._categories.Categories);
                return categories;
            }

        }

        public UDS SelectedUdstillingsGenstand
        {
            get
            {
                return _selectedUdstillingsGenstand;
            }
            set
            {

                _selectedUdstillingsGenstand = value;
                if (value != null)
                {
                    if (SelectedCategory != value.Category)
                    {
                        SelectedCategory = value.Category;
                        OnPropertyChanged("SelectedCategory");
                    }
                }

                OnPropertyChanged();
            }
        }     

        #endregion

        #region RelayCommandProperties

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        #endregion

        #region Methods

        public void toSaveCommand()
        {

            //TODO save to file
            //UdstillingsColl.Update(SelectedUdstillingsGenstand);
        }

        public void toDeleteCommand()
        {
            _udstillingsGenstande.Remove(SelectedUdstillingsGenstand);
            
            OnPropertyChanged(nameof(UdstillingsGenstande));
        }

        #endregion
  

    }
}

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
        private LocationCollection _locationCollection;
        private Location _selectedLocation;
        private ObservableCollection<Location> _locations;

        #endregion

        #region Constructor

        public EditViewModel()
        {
            _locationCollection = new LocationCollection();
            _categories = CategoriesCollection.Instance;
            _udstillingsGenstande = UdsCollection.Instance;

            Loadcollections();



            SaveCommand = new RelayCommand(toSaveCommand);
            DeleteCommand = new RelayCommand(toDeleteCommand);
        }
        #endregion

        #region Properties

        public ObservableCollection<Category> Categories
        {
            get
            {
                ObservableCollection<Category> categories = new ObservableCollection<Category>(this._categories.Categories);
                return categories;
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

                if (_selectedUdstillingsGenstand != null)
                {
                    _selectedUdstillingsGenstand.Category = value;
                    OnPropertyChanged(nameof(UdstillingsGenstande));
                }
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
                        OnPropertyChanged(nameof(SelectedCategory));
                    }

                    if (SelectedLocation != value.Location)
                    {
                        SelectedLocation = value.Location;
                        OnPropertyChanged(nameof(SelectedLocation));
                    }
                }
                OnPropertyChanged();

                
            }
        }

        public ObservableCollection<UDS> UdstillingsGenstande
        {
            get
            {
                ObservableCollection<UDS> collection = new ObservableCollection<UDS>(_udstillingsGenstande.UDScollection);
                return collection;
            }

        }


        public ObservableCollection<Location> Locations
        {
            get
            {              
                ObservableCollection<Location> collection = new ObservableCollection<Location>(_locationCollection.Locations);
                return collection;
            }
        }

        public Location SelectedLocation
        {
            get
            {
                return _selectedLocation;
            }
            set
            {
                _selectedLocation = value;

                if (_selectedUdstillingsGenstand != null)
                {
                    _selectedUdstillingsGenstand.Location = value;
                    OnPropertyChanged(nameof(UdstillingsGenstande));
                }
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

        private async Task Loadcollections()
        {
            await _locationCollection.UpdateLocationsAsync();
            OnPropertyChanged(nameof(Locations));

            await _udstillingsGenstande.LoadElementsAsync();
            OnPropertyChanged(nameof(UdstillingsGenstande));

        }

    }
}

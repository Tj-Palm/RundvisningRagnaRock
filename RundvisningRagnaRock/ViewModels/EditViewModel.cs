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
        private bool _visibillitytype;
        private bool _visibillitykunstner;
        private string _instrumentType;
        private string _kunstner;

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

                    if (value.GetType() == typeof(Instrument))
                    {
                        Instrument ins = (Instrument)value;

                        _kunstner = ins.Kunstner;
                        _instrumentType = ins.Type;

                        VisibillityKunstner = true;
                        VisibillityType = true;
                    }
                    else
                    {
                        VisibillityKunstner = false;
                        VisibillityType = false;

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

        public string SelectedType { get; set; }

        public ObservableCollection<string> Types
        {
            get
            {
                var collection = new ObservableCollection<string>(_udstillingsGenstande.UdsTypeList);
                return collection;
            }
        }

        public string Kunstner
        {
            get { return _kunstner; }
            set { _kunstner = value; OnPropertyChanged();}
        }

        public string InstrumentType
        {
            get { return _instrumentType; }
            set { _instrumentType = value;OnPropertyChanged(); }
        } 

        public bool VisibillityKunstner
        {
            get { return _visibillitykunstner; }
            set { _visibillitykunstner = value;OnPropertyChanged(); }
        }

        public bool VisibillityType
        {
            get { return _visibillitytype; }
            set { _visibillitytype = value; OnPropertyChanged();}
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

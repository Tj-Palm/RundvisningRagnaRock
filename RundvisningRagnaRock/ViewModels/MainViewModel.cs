using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Common;
using RundvisningRagnaRock.Enums;
using RundvisningRagnaRock.Models;
using RundvisningRagnaRock.Views;

namespace RundvisningRagnaRock.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        #region InstanceFields
        private string _map;
        private readonly string _map2 = "../Assets/Kort1.jpg";
        private readonly string _map3 = "../Assets/Kort2.jpg";
        private ObservableCollection<Location> _buttons;
        private Location SelectedLocation;
        private List<Location> _etage2Locations;
        private List<Location> _etage3Locations;
        private List<Location> _allLocations;
        private List<UDS> _allUds;
        private ObservableCollection<UDS> _selectedUdsByLocation;
        private UDS _selectedUdstillingsGenstand;

        #endregion

        public string maps
        {
            get { return _map2; }
        }

        #region Constructor

        public MainViewModel()
        {
            _etage2Locations = new List<Location>();
            _etage3Locations = new List<Location>();
            _allLocations = new List<Location>();
            _buttons = new ObservableCollection<Location>();
            _allUds = UdsCollection.Instance.UDScollection;
            _selectedUdsByLocation = new ObservableCollection<UDS>(_allUds); 
            //_buttons.Add(new DynamicButton(115, 50,50,30));
            //_buttons.Add(new DynamicButton(33, 123, 36, 48));

            LoadResourcesAsync();

            Map = _map2;

            ChangeToMap2 = new RelayCommand(toChangeMap2);
            ChangeToMap3 = new RelayCommand(toChangeMap3);
            SetLocation = new RelayCommandWithParamitter(toSetLocation,true);
        }

        #endregion

        #region Properties

        public UDS SelectedUdstillingsGenstand
        {
            get { return _selectedUdstillingsGenstand; }
            set { _selectedUdstillingsGenstand = value; OnPropertyChanged(); }
        }

        public string Map
        {
            get { return _map; }
            set { _map = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Location> Buttons
        {
            get
            {
                ;
                return _buttons;
            }
            set
            {
                _buttons = value;
                OnPropertyChanged();
            }
        }

        public Location _selectedLocation
        {
            get { return SelectedLocation; }
            set
            {
                SelectedLocation = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<UDS> SelectedUdsByLocation 
        {
            get
            {
                foreach (UDS Uds in _allUds)
                {
                    if (SelectedLocation.Id == Uds.Location.Id)
                    {
                        _selectedUdsByLocation.Add(Uds);
                    }
                }
                return _selectedUdsByLocation;
            }
        }

        #endregion

        #region RelayCommand Properties

        public RelayCommand ChangeToMap2 { get; set; }
        public RelayCommand ChangeToMap3 { get; set; }
        public RelayCommandWithParamitter SetLocation { get; set; }

        #endregion

        #region CommandMethods
        
        private void toChangeMap2()
        {
            Map = _map2;
            Buttons = new ObservableCollection<Location>(_etage2Locations);
        }


        private void toChangeMap3()
        {
            Map = _map3;
            Buttons = new ObservableCollection<Location>(_etage3Locations);
        }


        //private int id;

        //public int ID
        //{
        //    get { return id; }
        //    set
        //    {
        //        id = value;
        //        OnPropertyChanged();
        //    }
        //}


        private void toSetLocation(object id)
        {


            int ID = Convert.ToInt16(id);

            foreach (Location location in _allLocations)
            {
                if (location.Id == ID)
                {
                    SelectedLocation = location;
                }
            }
        }

        #endregion

        #region Async methods

        private async Task LoadResourcesAsync()
        {
            LocationCollection locations = new LocationCollection();
            await locations.UpdateLocationsAsync();

            _allLocations = locations.Locations;

            _etage2Locations.Clear();
            _etage3Locations.Clear();

            foreach (Location location in locations.Locations)
            {
                if (location.Etage == Etage.Two)
                {
                    _etage2Locations.Add(location);
                }
                else if (location.Etage == Etage.Three)
                {
                    _etage3Locations.Add(location);
                }
                else
                {
                   throw new MissingLocationException($"{location.Name} location does not exist");
                }
            }

        }

        #endregion
    }
}
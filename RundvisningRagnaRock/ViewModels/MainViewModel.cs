using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        private ObservableCollection<UDS> _observableUdsCollection;
        
        #endregion

        #region Constructor

        public MainViewModel()
        {
            _etage2Locations = new List<Location>();
            _etage3Locations = new List<Location>();
            _allLocations = new List<Location>();
            _buttons = new ObservableCollection<Location>();
            _allUds = UdsCollection.Instance.UDScollection;
            //_buttons.Add(new DynamicButton(115, 50,50,30));
            //_buttons.Add(new DynamicButton(33, 123, 36, 48));


            LoadResourcesAsync();

            Map = _map2;

            ChangeToMap2 = new RelayCommand(toChangeMap2);
            ChangeToMap3 = new RelayCommand(toChangeMap3);
            GetUDS = new RelayCommand(toGetUDS);
        }

        #endregion

        #region Properties

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
        //public List<UDS> UdstillingsGenstande
        //{
        //    get
        //    {
        //        _observableUdsCollection

        //        return _observableUdsCollection;
        //    }

        //}

        #endregion

        #region RelayCommand Properties

        public RelayCommand ChangeToMap2 { get; set; }
        public RelayCommand ChangeToMap3 { get; set; }
        public RelayCommand GetUDS { get; set; }

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

        private void toGetUDS()
        {
            //LocationCollection locations = new LocationCollection();
            //locations.SaveLocations();
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
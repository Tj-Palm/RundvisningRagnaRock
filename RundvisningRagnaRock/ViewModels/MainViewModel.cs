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
using RundvisningRagnaRock.Models;
using RundvisningRagnaRock.Views;

namespace RundvisningRagnaRock.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        private string _map;
        private readonly string _map2 = "../Assets/Kort1.jpg";
        private readonly string _map3 = "../Assets/Kort2.jpg";
        private ObservableCollection<DynamicButton> _buttons;
        


        public MainViewModel()
        {
           
            _buttons = new ObservableCollection<DynamicButton>();
            _buttons.Add(new DynamicButton(115, 50,50,30));
            _buttons.Add(new DynamicButton(33, 123, 36, 48));

            Map = _map2;

            ChangeToMap2 = new RelayCommand(toChangeMap2);
            ChangeToMap3 = new RelayCommand(toChangeMap3);
            GetUDS = new RelayCommand(toGetUDS);
        }

        public string Map
        {
            get { return _map; }
            set { _map = value; OnPropertyChanged(); }
        }

        public RelayCommand ChangeToMap2 { get; set; }
        public RelayCommand ChangeToMap3 { get; set; }
        public RelayCommand GetUDS { get; set; }

        private void toChangeMap2()
        {
            Map = _map2;
        }

        private void toChangeMap3()
        {
            Map = _map3;

            LocationCollection lok = new LocationCollection();

            lok.SaveLocations();

            lok.AddLocation(new Location(new DynamicButton(30, 30, 30, 30), "test3", "test3", "test3"));
        }

        private void toGetUDS()
        {

        }

        public ObservableCollection<DynamicButton> Buttons
        {
            get { return _buttons; }
            set { _buttons = value; }
        }



    }
}
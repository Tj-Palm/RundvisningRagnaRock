using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Common;
using RundvisningRagnaRock.Views;

namespace RundvisningRagnaRock.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        private string _map;
        private readonly string _map2 = "../Assets/Kort1.jpg";
        private readonly string _map3 = "../Assets/Kort2.jpg";

        public MainViewModel()
        {
            Map = _map2;

            ChangeToMap2 = new RelayCommand(toChangeMap2);
            ChangeToMap3 = new RelayCommand(toChangeMap3);
        }

        public string Map
        {
            get { return _map; }
            set { _map = value; OnPropertyChanged(); }
        }

        public RelayCommand ChangeToMap2 { get; set; }
        public RelayCommand ChangeToMap3 { get; set; }

        private void toChangeMap2()
        {
            Map = _map2;
        }

        private void toChangeMap3()
        {
            Map = _map3;
        }

    }
}
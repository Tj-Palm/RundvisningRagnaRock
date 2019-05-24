using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Binding_MVVM.Persistency;
using RundvisningRagnaRock.Enums;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{
    public class LocationCollectionNew
    {

        #region Singleton
        private static LocationCollectionNew _instance;

        public static LocationCollectionNew Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LocationCollectionNew();
                    return _instance;
                }

                return _instance;
            }
        }
        #endregion


        private LocationCollectionNew()
        {
            var t = new Location(10, 10, 10, 10, 3, "test1", "test1", "test");
            _location = new List<Location>();

            _location.Add(t);
            _location.Add(new Location(20, 20, 20, 20, 3, "test2", "test2", "test"));
            _location.Add(new Location(30, 30, 30, 30, 2, "test3", "test3", "test"));
            _location.Add(new Location(40, 40, 40, 40, 2, "test4", "test4", "test"));
            SelectedLocation = _location[0];
        }

  

        private List<Location> _location;

        public List<Location> Locations
        {
            get { return _location; }
            set { _location = value; }
        }


        public Location SelectedLocation { get; set; }

        public List<Location> Etage2List { get; set; }
        public List<Location> Etage3List { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Binding_MVVM.Persistency;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{
    public class LocationCollection
    {
        private List<Location> _locations;
        private FilePersistency<List<Location>> file;

        public LocationCollection()
        {
            _locations = new List<Location>();
            file = new FilePersistency<List<Location>>("Locations");           
        }

        public List<Location> Locations
        {
            get { return _locations; }
            set { _locations = value; }
        }

        public async Task UpdateLocationsAsync()
        {
          
            _locations = await file.LoadModelAsync();
        }

        public async void AddLocation(Location location)
        {
            _locations = await file.LoadModelAsync();
            _locations.Add(location);
            await file.SaveAsync(_locations);
        }

        public async void SaveLocations()
        {
            _locations.Add(new Location(new DynamicButton(10, 10, 10, 10), "test1", "test1", "test1"));
            _locations.Add(new Location(new DynamicButton(20, 20, 20, 20), "test2", "test2", "test2"));
            _locations.Add(new Location(new DynamicButton(30, 30, 30, 30), "test3", "test3", "test3"));

            await file.SaveAsync(_locations);
        }

    }
}

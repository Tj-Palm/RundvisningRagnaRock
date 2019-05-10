using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Binding_MVVM.Persistency;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{
    class LocationCollection
    {
        private List<Location> Locations;
        private FilePersistency<List<Location>> file;


        public LocationCollection()
        {
            Locations = new List<Location>();
            file = new FilePersistency<List<Location>>();
        }

        public List<Location> GetLocations
        {
            get { return Locations; }
        }

        public async void AddLocation(Location location)
        {
            Locations = await file.LoadModelAsync();

            Locations.Add(location);

            await file.SaveAsync(Locations);
        }

        public async void SaveLocations()
        {
            Locations.Add(new Location(new DynamicButton(10,10,10,10), "test1","test1","test1"));
            Locations.Add(new Location(new DynamicButton(20, 20, 20, 20), "test2", "test2", "test2"));
            Locations.Add(new Location(new DynamicButton(30, 30, 30, 30), "test3", "test3", "test3"));

            await file.SaveAsync(Locations);
        }



    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Binding_MVVM.Persistency;
using RundvisningRagnaRock.Enums;
using RundvisningRagnaRock.Models;


namespace RundvisningRagnaRock.Collections
{

    /// <summary>
    /// LocationCollection 
    /// </summary>
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
            get
            {
                if (_locations != null)
                {
                    return _locations;
                }

                return new List<Location>();
            }
            set { _locations = value; }
        }

        public async Task UpdateLocationsAsync()
        {
            if (!File.Exists(file.Folder.Path + "\\Locations.json"))
            {
                await SaveLocations();
            }
            _locations = await file.LoadModelAsync();
        }

        public async void AddLocation(Location location)
        {
            _locations = await file.LoadModelAsync();
            _locations.Add(location);
            await file.SaveAsync(_locations);
        }

        public async Task SaveLocations()
        {
            _locations.Add(new Location(10, 10, 10, 10, Etage.Three, "test1", "test1","test"));
            _locations.Add(new Location(20, 20, 20, 20, Etage.Three, "test2", "test2","test"));
            _locations.Add(new Location(30, 30, 30, 30, Etage.Two, "test3", "test3","test"));
            _locations.Add(new Location(40, 40, 40, 40, Etage.Two, "test4", "test4", "test"));
            await file.SaveAsync(_locations);
        }
    }
}

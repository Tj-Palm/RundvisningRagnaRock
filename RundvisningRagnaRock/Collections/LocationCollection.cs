﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Binding_MVVM.Persistency;
using RundvisningRagnaRock.Enums;
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
            _locations.Add(new Location(10, 10, 10, 10, Etage.Three, "test1", "test1","test"));
            _locations.Add(new Location(20, 20, 20, 20, Etage.Three, "test2", "test2","test"));
            _locations.Add(new Location(30, 30, 30, 30, Etage.Two, "test3", "test3","test"));
            _locations.Add(new Location(40, 40, 40, 40, Etage.Two, "test4", "test4", "test"));
            await file.SaveAsync(_locations);
        }

    }
}

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
    /// LocationCollection en collection af Locations
    /// </summary>
    public class LocationCollection
    {

        #region Instance fields
        /// <summary>
        /// locations list
        /// filepersistency
        /// </summary>
        private List<Location> _locations;
        private FilePersistency<List<Location>> _file;
        #endregion

        #region Constructor
        /// <summary>
        /// initialisere _location og _file
        /// </summary>      
        public LocationCollection()
        {
            _locations = new List<Location>();
            _file = new FilePersistency<List<Location>>("Locations");   
            
            
        }
        #endregion

        #region Properties

        /// <summary>
        /// retunere en liste af locations
        /// </summary>
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
        #endregion

        #region Methods
        /// <summary>
        /// henter locations fra Locations.json
        /// </summary>
        /// <returns></returns>
        public async Task UpdateLocationsAsync()
        {
            if (!File.Exists(_file.Folder.Path + "\\Locations.json"))
            {
                await SaveLocations();
            }
            _locations = await _file.LoadModelAsync();
        }


        /// <summary>
        /// tilføjer en location 
        /// </summary>
        /// <param name="location"></param>
        public async void AddLocation(Location location)
        {
            _locations = await _file.LoadModelAsync();
            _locations.Add(location);
            await _file.SaveAsync(_locations);
        }

        /// <summary>
        /// hvis location er tom opretter den dette testdatai en json fil.
        /// </summary>
        /// <returns></returns>
        public async Task SaveLocations()
        {
            _locations.Add(new Location(10, 10, 10, 10, Etage.Three, "test1", "test1","test"));
            _locations.Add(new Location(20, 20, 20, 20, Etage.Three, "test2", "test2","test"));
            _locations.Add(new Location(30, 30, 30, 30, Etage.Two, "test3", "test3","test"));
            _locations.Add(new Location(40, 40, 40, 40, Etage.Two, "test4", "test4", "test"));
            await _file.SaveAsync(_locations);
        }
        #endregion
    }
}

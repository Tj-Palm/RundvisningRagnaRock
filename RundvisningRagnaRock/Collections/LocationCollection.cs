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
            _locations.Add(new Location(25, 196, 39, 37, Etage.Three, "Blikfang", "",""));
            _locations.Add(new Location(50, 158, 45, 45, Etage.Three, "Skaelv", "",""));
            _locations.Add(new Location(34, 283, 60, 37, Etage.Three, "Musikkens strømme", "",""));
            _locations.Add(new Location(-5, 10, 45, 45, Etage.Two, "Dansefeber", "", ""));
            _locations.Add(new Location(-35, 137, 45, 45, Etage.Three, "Lad der blive lys", "", ""));
            _locations.Add(new Location(33, 123, 36, 48, Etage.Two, "Demoteket", "", ""));
            _locations.Add(new Location(18, 290, 32, 50, Etage.Two, "Elektrisk intimitet", "", ""));
            _locations.Add(new Location(45, 50, 50, 31, Etage.Two, "Jagten på den fede lyd", "", ""));
            _locations.Add(new Location(8, 454, 58, 36, Etage.Two, "Fandrenge, Fanpiger", "", ""));
            _locations.Add(new Location(-40, 197, 36, 54, Etage.Two, "Rotation", "", ""));
            _locations.Add(new Location(30, 293, 29, 59, Etage.Two, "Den røde tråd", "", ""));
            await _file.SaveAsync(_locations);
        }
        #endregion
    }
}

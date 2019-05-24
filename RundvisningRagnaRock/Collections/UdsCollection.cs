﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Devices.Sensors;
using Windows.Gaming.Input;
using RundvisningRagnaRock.Models;


namespace RundvisningRagnaRock.Collections
{
    public class UdsCollection
    {

        #region Instancefields

        private List<UDS> _udsCollection;
        private static UdsCollection _instance;
        private LocationCollection locations;
        private List<UDS> _selectedUdsListByLocation;
        #endregion

        #region Constructor

        private UdsCollection()
        {
            _udsCollection = new List<UDS>();

          
        }


        

        #endregion

        public async Task LoadElementsAsync()
        {
            if (_udsCollection.Count == 0)
            {
                locations = new LocationCollection();
                await locations.UpdateLocationsAsync();

                _selectedUdsListByLocation = new List<UDS>();

                ////TODO for testing. delete
                //_udsCollection.Add(new UDS("Lemmings Guitar", CategoriesCollection.Instance.Categories[1], locations.Locations[0],
                //    "Denne guitar er super fed.", "", ""));
                //_udsCollection.Add(new UDS("Flemmings Guitar", CategoriesCollection.Instance.Categories[2], locations.Locations[1],
                //    "Denne guitar er super super fed.", "", ""));
                //_udsCollection.Add(new UDS("Flubbers Guitar", CategoriesCollection.Instance.Categories[0], locations.Locations[2],
                //    "Denne guitar er super super super fed.", "", ""));
                //_udsCollection.Add(new UDS("Flubbers Guitar", CategoriesCollection.Instance.Categories[3], locations.Locations[3],
                //    "Denne guitar er super super super fed.", "", ""));
                //_udsCollection.Add(new Instrument("instrument Guitar", CategoriesCollection.Instance.Categories[3], locations.Locations[3],
                //    "Frank", "Guitar","",""));
            }
        }

        private List<string> _udsTypesList;

        public List<string> UdsTypeList
        {
            get
            {
                List<string> collection = new List<string>();
                collection.Add(typeof(Instrument).Name);

                return collection;
            }          
        }


        #region Singeltonprop

        public static UdsCollection Instance
        {
            get
            {
                if (_instance == null )
                {
                    _instance = new UdsCollection();
                    return _instance;
                }
                else
                {
                    return _instance;
                }
            }
        }

        #endregion

        #region Properties

        public List<UDS> UDScollection
        {
            get { return _udsCollection; }
            private set { _udsCollection = value; }
        }

   

        public List<UDS> SelectedUdsListByLocation
        {
            get { return _selectedUdsListByLocation; }
            set { _selectedUdsListByLocation = value; }
        }


        #endregion

        #region Methods


        public bool Add(UDS uds)
        {           

            if (uds != null && locations.Locations.Contains(uds.Location) && CategoriesCollection.Instance.Categories.Contains(uds.Category))
            {                              
                 UDScollection.Add(uds);

                if (UDScollection.Contains(uds))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

                return false;
            
        }

        public void Remove(UDS uds)
        {
            if (uds != null)
            {
                UDScollection.Remove(uds);
            }
        }


        #endregion

    }
}

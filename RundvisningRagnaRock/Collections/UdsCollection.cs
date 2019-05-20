﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Devices.Sensors;
using RundvisningRagnaRock.Models;


namespace RundvisningRagnaRock.Collections
{
    public class UdsCollection
    {

        #region Instancefields

        private List<UDS> _udsCollection;
        private static UdsCollection _instance;
        private LocationCollection lokocations;
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
                lokocations = new LocationCollection();
                await lokocations.UpdateLocationsAsync();

                //TODO for testing. delete
                _udsCollection.Add(new UDS("Lemmings Guitar", CategoriesCollection.Instance.Categories[1], lokocations.Locations[0],
                    "Denne guitar er super fed.", "", ""));
                _udsCollection.Add(new UDS("Flemmings Guitar", CategoriesCollection.Instance.Categories[2], lokocations.Locations[1],
                    "Denne guitar er super super fed.", "", ""));
                _udsCollection.Add(new UDS("Flubbers Guitar", CategoriesCollection.Instance.Categories[0], llokocationsok.Locations[2],
                    "Denne guitar er super super super fed.", "", ""));
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

        #endregion

        #region Methods


        public bool Add(UDS uds)
        {           

            if (uds != null && lokocations.Locations.Contains(uds.Location) && CategoriesCollection.Instance.Categories.Contains(uds.Category))
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

        //Not in use. Data er automatisk opdateret via observerble collection i viewmodel.

        //public void Update(UDS uds)
        //{
        //    if (uds != null)
        //    {
        //        int index =0;
        //        bool found =false;

        //        foreach (var item in UDScollection)
        //        {
        //            if (item.ID == uds.ID)
        //            {
        //                index = UDScollection.IndexOf(item);
        //                found = true;
        //                //UDScollection[UDScollection.IndexOf(item)] = uds;
        //            }
        //        }

        //        if(found)
        //            UDScollection[index] = uds;
        //    }
        //}
        #endregion

    }
}

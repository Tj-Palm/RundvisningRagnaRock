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
    class UdsCollection
    {

        #region Instancefields

        private List<UDS> _udsCollection;
        private static UdsCollection _instance;

        #endregion

        #region Constructor

        private UdsCollection()
        {
        _udsCollection = new List<UDS>();


        //TODO for testing. delete
        _udsCollection.Add(new UDS("Lemmings Guitar", CategoriesCollection.Instance.Categories[1], "Fortet", "Denne guitar er super fed.", "", ""));
        _udsCollection.Add(new UDS("Flemmings Guitar", CategoriesCollection.Instance.Categories[2], "Settet", "Denne guitar er super super fed.", "", ""));
        _udsCollection.Add(new UDS("Flubbers Guitar", CategoriesCollection.Instance.Categories[0], "Beast", "Denne guitar er super super super fed.", "", ""));
        }

        #endregion

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

            if (uds != null)
            {                              
                UDScollection.Add(uds);
            }

            if (UDScollection.Contains(uds))
            {
                return true;
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

        public void Update(UDS uds)
        {
            if (uds != null)
            {
                int index =0;
                bool found =false;

                foreach (var item in UDScollection)
                {
                    if (item.ID == uds.ID)
                    {
                        index = UDScollection.IndexOf(item);
                        found = true;
                        //UDScollection[UDScollection.IndexOf(item)] = uds;
                    }
                }

                if(found)
                    UDScollection[index] = uds;
            }



        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{
    class UdsCollection
    {

        #region Instancefields

        private List<UDS> _udsCollection;

        #endregion

        #region Constructor

        public UdsCollection()
        {
        _udsCollection = new List<UDS>();
          
        }
        #endregion

        #region Methods
        public List<UDS> UDScollection
        {
            get { return _udsCollection; }
            private set { _udsCollection = value; }
        }

        public void Add(UDS uds)
        {
            if (uds != null)
            UDScollection.Add(uds);
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
                foreach (var item in UDScollection)
                {
                    if (item.ID == uds.ID)
                    {
                        UDScollection[UDScollection.IndexOf(item)] = uds;
                    }
                }
            }
        }
        #endregion

    }
}

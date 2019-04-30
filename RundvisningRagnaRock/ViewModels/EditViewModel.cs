using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Annotations;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Models;


namespace RundvisningRagnaRock.ViewModels
{
    class EditViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _udstillingsGenstande = new ObservableCollection<string>();

        private UdsCollection UdstillingsColl;

        public ObservableCollection<UDS> UdstillingsGenstande
        {
            get
            {
                ObservableCollection<UDS> collection = new ObservableCollection<UDS>(UdstillingsColl.UDScollection);
                return collection;
            }
      
        }

        public EditViewModel()
        {
           UdstillingsColl = UdsCollection.Instance;
           UdstillingsColl.Add(new UDS("Lemmings Guitar", "Guitar", "Fortet", "Denne guitar er super fed.","",""));
           UdstillingsColl.Add(new UDS("Flemmings Guitar", "Guitar", "Settet", "Denne guitar er super super fed.", "", ""));
           UdstillingsColl.Add(new UDS("Flubbers Guitar", "Guitar", "Beast", "Denne guitar er super super super fed.", "", ""));
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}

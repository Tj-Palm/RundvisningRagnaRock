using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Annotations;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Common;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.ViewModels
{
    public class GUICreateViewModel : INotifyPropertyChanged
    {
        public GUICreateViewModel()
        {
            AddCommand = new RelayCommand(ToAddUds);
        }

        public RelayCommand AddCommand { get; set; }

        private UDS _newUDS;

        public UDS NewUDS
        {
            get { return _newUDS;}
            set { _newUDS = value; OnPropertyChanged(); }
        }

        public void ToAddUds()
        {
            UdsCollection.Instance.Add(new UDS(NewUDS.Name,NewUDS.Category,NewUDS.Location,NewUDS.Description,NewUDS.PictureDirectory,NewUDS.SoundFileDirectory));

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

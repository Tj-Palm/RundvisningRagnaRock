using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Annotations;

namespace RundvisningRagnaRock.ModelViews
{
    class EditViewModel : INotifyPropertyChanged
    {

        ObservableCollection<string> buttons = new ObservableCollection<string>()
        {
            "Test1",
            "Test2",
            "Test3"
        };

        public ObservableCollection<string> Buttons
        {
            get { return buttons; }
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

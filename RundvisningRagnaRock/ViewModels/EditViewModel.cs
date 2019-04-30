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
using RundvisningRagnaRock.Common;
using RundvisningRagnaRock.Models;


namespace RundvisningRagnaRock.ViewModels
{
    class EditViewModel : INotifyPropertyChanged
    {


        #region Instance fields

        private ObservableCollection<string> _udstillingsGenstande = new ObservableCollection<string>();
        private ObservableCollection<Category> categoriesCollection = new ObservableCollection<Category>();

        private CategoriesCollection categories;
        private UdsCollection UdstillingsColl;

        #endregion

        #region Constructor

        public EditViewModel()
        {
            categories = CategoriesCollection.Instance;
            UdstillingsColl = UdsCollection.Instance;





            //TODO for testing. is to be deleted.

            categories.AddCategory("Guitar", "test1");
            categories.AddCategory("Trommer", "test2");
            categories.AddCategory("Bas", "test3");
            categories.AddCategory("sanger", "test4");

            UdstillingsColl.Add(new UDS("Lemmings Guitar", null, "Fortet", "Denne guitar er super fed.", "", ""));
            UdstillingsColl.Add(new UDS("Flemmings Guitar", null, "Settet", "Denne guitar er super super fed.", "", ""));
            UdstillingsColl.Add(new UDS("Flubbers Guitar", null, "Beast", "Denne guitar er super super super fed.", "", ""));
        }

        #endregion

        #region Properties

        public ObservableCollection<UDS> UdstillingsGenstande
        {
            get
            {
                ObservableCollection<UDS> collection = new ObservableCollection<UDS>(UdstillingsColl.UDScollection);
                return collection;
            }

        }

        public ObservableCollection<Category> Categories
        {
            get
            {
                ObservableCollection<Category> categories = new ObservableCollection<Category>(this.categories.Categories);
                return categories;
            }

        }

        public RelayCommand SaveCommand { get; set; }

        #endregion

        #region Methods

        public void toSaveCommand()
        {
            UdstillingsColl.Update();
        }
        #endregion







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

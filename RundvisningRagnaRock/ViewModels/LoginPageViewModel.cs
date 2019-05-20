using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.ApplicationSettings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using RundvisningRagnaRock.Annotations;
using RundvisningRagnaRock.Collections;
using RundvisningRagnaRock.Common;
using RundvisningRagnaRock.Models;
using RundvisningRagnaRock.Views;

namespace RundvisningRagnaRock.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private EmployeeCollection _employee;
        private EmployeeCollection _employeeCollection;
        private string _username;
        private int _password;
        
        
        public LoginPageViewModel()
        {
            _employee = new EmployeeCollection();
            LoginCommand = new RelayCommand(toLoginCommand);
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public int Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public RelayCommand LoginCommand { get; set; }

        public void toLoginCommand()
        {
            _employee.RequestLogin(Username, Password);

            if (_employee.RequestLogin(Username, Password))
            {
                var frame = new Frame();
                frame.Navigate(typeof(EditPage));

                Window.Current.Content = frame;
                Window.Current.Activate();
            }
        }
        
     
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RundvisningRagnaRock.Models
{
    public class Employee
    {
        private string _name;
        private int _password;

        public Employee(string Name, int Password)
        {
            _name = Name;
            _password = Password;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Password
        {
            get { return _password; }
        }
    }
}

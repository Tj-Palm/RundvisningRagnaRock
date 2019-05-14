using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{
    public class EmployeeCollection
    {
        private string _name;
        private int _password;

        private EmployeeCollection()
        {

            Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();
            Employees.Add(1, new Employee("Nikolaj", 12345));
            Employees.Add(2, new Employee("Sarah", 12345));
            Employees.Add(3, new Employee("Benjamin", 12345));
            Employees.Add(4, new Employee("Daniel", 12345));

        }
        public Dictionary<int, Employee> Employees = new Dictionary<int, Employee>();

        public bool RequestLogin(string Username, int Password)
        {
            foreach (var item in Employees) // Dictionary
            {
                if (Employees.ContainsKey(1))
                {
                    return true;
                }
                else if (Employees.ContainsKey(2))
                {
                    return true;
                }
                else if (Employees.ContainsKey(3))
                {
                    return true;
                }
                else if (Employees.ContainsKey(4))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
            //Todo - Input find key in dictionary - EmployeeCollection
            //If key is found - Login
            //Else Error message
        }
    }
}

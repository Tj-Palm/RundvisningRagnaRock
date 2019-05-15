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
        public EmployeeCollection()
        {

            Employees = new Dictionary<int, Employee>();
            Employees.Add(1, new Employee("Nikolaj", 12345));
            Employees.Add(2, new Employee("Sarah", 12345));
            Employees.Add(3, new Employee("Benjamin", 12345));
            Employees.Add(4, new Employee("Daniel", 12345));

        }

        public Dictionary<int, Employee> Employees;

        public bool RequestLogin(string Username, int Password)
        {
            foreach (var item in Employees) // Dictionary
            {
                if (item.Value.Name == Username && item.Value.Password == Password)
                {
                    return true;
                }
            }
            return false;
            //Todo - Input find key in dictionary - EmployeeCollection
            //If key is found - Login
            //Else Error message
        }
    }
}

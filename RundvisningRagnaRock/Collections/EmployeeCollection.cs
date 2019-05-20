using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binding_MVVM.Persistency;
using RundvisningRagnaRock.Models;

namespace RundvisningRagnaRock.Collections
{
    public class EmployeeCollection
    {
        private static FilePersistency<Employee> _fileSourceEmployee;
        private static Employee _employee;

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
            foreach (var elements in Employees)
            {
                if (elements.Value.Name == Username && elements.Value.Password == Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

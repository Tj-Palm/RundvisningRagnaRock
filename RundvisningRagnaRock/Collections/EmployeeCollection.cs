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

        private EmployeeCollection()
        {

        _employeeCollection = new Dictionary<int, Employee>();
        
        _employeeCollection.Add(1, new Employee("Daniel", 12345));
        _employeeCollection.Add(2, new Employee("Nikolaj", 12345));
        _employeeCollection.Add(3, new Employee("Sarah", 12345));
        _employeeCollection.Add(4, new Employee("Benjamin", 12345));
        }

        private Dictionary<int, Employee> _employeeCollection;

    }
}

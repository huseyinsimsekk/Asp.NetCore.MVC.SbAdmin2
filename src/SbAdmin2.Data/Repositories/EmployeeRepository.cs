using SbAdmin2.Core.Contracts;
using SbAdmin2.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SbAdmin2.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        private MainContext MainContext { get => _mainContext as MainContext; }
        public EmployeeRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}

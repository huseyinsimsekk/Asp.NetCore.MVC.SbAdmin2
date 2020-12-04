
using SbAdmin2.Core.Contracts;
using SbAdmin2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SbAdmin2.Service.Services
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        public EmployeeService(IRepository<Employee> repository) : base(repository)
        {
        }

        public int ActiveEmployeeCount()
        {
            return _repository.GetManyAsync(m => !m.IsDeleted).Count();
        }

        public decimal SumSalary(Func<Employee, bool> predicate)
        {
            return _repository.GetManyAsync(predicate).Sum(m => m.Salary);
        }
    }
}

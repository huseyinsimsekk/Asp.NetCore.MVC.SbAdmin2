using SbAdmin2.Data.Models;
using SbAdmin2.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SbAdmin2.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        public void Add(Employee model)
        {
            if (model == null)
            {
                throw new Exception("Employee model is null!");
            }
        }

        public void Delete(Employee model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}

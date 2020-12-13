using SbAdmin2.Core.Contracts;
using SbAdmin2.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SbAdmin2.Service.Services
{
    public class AlertService : IAlertService
    {
        public IRepository<Alert> _repository;
        public AlertService(IRepository<Alert> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Alert>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Alert> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public IEnumerable<Alert> GetManyAsync(Func<Alert, bool> expression)
        {
            return _repository.GetManyAsync(expression);
        }
    }
}

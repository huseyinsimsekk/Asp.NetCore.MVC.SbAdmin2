using SbAdmin2.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SbAdmin2.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        public IRepository<T> _repository;
        private IUnitOfWork _unitOfWork;
        public Service(IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(T model)
        {
           await _repository.AddAsync(model);
           await _unitOfWork.CommitAsync();
        }

        public void Delete(T model)
        {
            _repository.Delete(model);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity;
        }

        public void Update(T model)
        {
            _repository.Update(model);
            _unitOfWork.Commit();
        }
    }
}

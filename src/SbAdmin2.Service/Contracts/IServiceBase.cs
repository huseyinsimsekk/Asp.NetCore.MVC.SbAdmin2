using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SbAdmin2.Service.Contracts
{
    public interface IServiceBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void Add(T model);
        void Delete(T model);
        void Update(T model);
    }
}

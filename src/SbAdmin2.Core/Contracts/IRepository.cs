using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SbAdmin2.Core.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T model);
        void Delete(T model);
        void Update(T model);
        IEnumerable<T> GetManyAsync(Func<T, bool> predicate);
    }
}

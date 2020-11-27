using Microsoft.EntityFrameworkCore;
using SbAdmin2.Core.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SbAdmin2.Data.Repositories
{
    public class Repository<T> : IRepositoryBase<T> where T : class
    {
        protected readonly MainContext _mainContext;
        private DbSet<T> _dbSet;
        public Repository(MainContext mainContext)
        {
            _mainContext = mainContext;
            _dbSet = _mainContext.Set<T>();
        }
        public void Add(T model)
        {
            _dbSet.Add(model);
        }

        public void Delete(T model)
        {
            _dbSet.Remove(model);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Update(T model)
        {
            _mainContext.Entry(model).State = EntityState.Modified;
        }
    }
}

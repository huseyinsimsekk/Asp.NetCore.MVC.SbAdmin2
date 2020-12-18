using Microsoft.EntityFrameworkCore;
using SbAdmin2.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SbAdmin2.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly MainContext _mainContext;
        private DbSet<T> _dbSet;
        public Repository(MainContext mainContext)
        {
            _mainContext = mainContext;
            _dbSet = _mainContext.Set<T>();
        }
        public async Task AddAsync(T model)
        {
            await _dbSet.AddAsync(model);
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

        public IEnumerable<T> GetManyAsync(Func<T, bool> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public void Update(T model)
        {
            _mainContext.Entry(model).State = EntityState.Modified;
        }
    }
}

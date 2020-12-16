using SbAdmin2.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SbAdmin2.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _mainContext;
        public UnitOfWork(MainContext mainContext)
        {
            _mainContext = mainContext;
        }
        public void Commit()
        {
            _mainContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _mainContext.SaveChangesAsync();
        }
    }
}

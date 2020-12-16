using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SbAdmin2.Core.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}

using SbAdmin2.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SbAdmin2.Core.Contracts
{
    public interface IAlertService
    {
        Task<IEnumerable<Alert>> GetAllAsync();
        IEnumerable<Alert> GetManyAsync(Func<Alert, bool> expression);
        Task<Alert> GetByIdAsync(int id);
    }
}

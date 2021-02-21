using System;
using System.Threading;
using System.Threading.Tasks;

namespace FADY.Services.Salary.Dmoain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task SaveEntitiesAsync(object cancellationToken);
    }
}

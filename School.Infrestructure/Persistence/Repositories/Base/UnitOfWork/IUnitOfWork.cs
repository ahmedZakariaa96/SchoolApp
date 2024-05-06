using School.Infrestructure.Persistence.Repositories.Base.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrestructure.Persistence.Repositories.Base.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepositoryBase<T> Repository<T>() where T : class;
        Task<int> CompleteAsync(CancellationToken cancellationToken);
        Task<int> CompleteAsync();
    }
}

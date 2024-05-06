using School.Infrestructure.Persistence.Repositories.Base.RepositoryBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace School.Infrestructure.Persistence.Repositories.Base.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
           return await this.dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CompleteAsync()
        {
            return await this.dbContext.SaveChangesAsync();
        }

        public IRepositoryBase<T> Repository<T>() where T : class
        {
            IRepositoryBase<T> repo =new RepositoryBase<T>(this.dbContext);
            return repo;
        }
    }
}

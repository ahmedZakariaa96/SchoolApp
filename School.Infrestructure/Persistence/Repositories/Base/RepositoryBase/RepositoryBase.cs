using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace School.Infrestructure.Persistence.Repositories.Base.RepositoryBase
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.dbContext.Set<T>().AsNoTracking().AsQueryable();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.dbContext.Set<T>().Where(expression).AsNoTracking().AsQueryable();
        }
        public IQueryable<T> FindByConditionAsTracking(Expression<Func<T, bool>> expression)
        {
            return this.dbContext.Set<T>().Where(expression).AsQueryable();
        }
        public async Task<T?> GetByIdAsync(int id)
        {

            return await this.dbContext.Set<T>().FindAsync(id);
        }



        public void Create(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            this.dbContext.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            this.dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.dbContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            this.dbContext.Set<T>().RemoveRange(entities);
        }
        //--------------------------------------------
        public IDbContextTransaction BeginTransaction()
        {


            return dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            dbContext.Database.CommitTransaction();
        }

        public void RollBack()
        {
            dbContext.Database.RollbackTransaction();

        }


    }
}

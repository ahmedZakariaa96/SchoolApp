using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrestructure.Persistence.Repositories.Base.RepositoryBase
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByConditionAsTracking(Expression<Func<T, bool>> expression);
        Task<T?> GetByIdAsync(int id);

        void Create(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        //--------------------------------------------
        IDbContextTransaction BeginTransaction();
        public void Commit();
        public void RollBack();
    }
}

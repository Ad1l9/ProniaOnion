using ProniaOnion.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Repositories.Generic
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        Task<IQueryable<T>> GetAll(
            bool isTracking = true,
            bool ignoreQuery = false,
            params string[] includes
            );
        Task<IQueryable<T>> GetAllAsync(
            Expression<Func<T, bool>>? expression = null,
            params string[] includes);

        IQueryable<T> GetAllAsync(
            Expression<Func<T, object>>? orderExpression = null,
            int skip = 0, int take = 0,
            bool isTracking = true,
            bool isDescending = false,
            params string[] includes);
        Task<T> GetByIdAsync(int id,bool isTracking=true,bool ignoreQuery=false, params string[] includes);
        Task<T> GetByExpressionAsync(Expression<Func<T,bool>> expression,bool isTracking=true,bool ignoreQuery=false, params string[] includes);

        Task<bool> IsExistAsync(Expression<Func<T,bool>> expression,bool ignoreQuery=false);

        Task AddAsync(T entity);

        void Update(T entity);
        void Delete(T entity);
        void SoftDelete(T entity);
        void ReverseSoftDelete(T entity);

        Task SaveChangesAsync();
    }
}

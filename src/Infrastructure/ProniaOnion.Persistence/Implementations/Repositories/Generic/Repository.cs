using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories.Generic;
using ProniaOnion.Domain.Entities.Base;
using ProniaOnion.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProniaOnion.Persistence.Implementations.Repositories.Generic
{
    public class Repository<T>:IRepository<T> where T:BaseEntity,new()
    {

        private readonly DbSet<T> _table;
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _table = context.Set<T>();
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }


        public Task<IQueryable<T>> GetAll(bool isTracking = true, bool ignoreQuery = false, params string[] includes)
        {
            IQueryable<T> query = _table;
            query = _AddIncludes(query, includes);
            if (!ignoreQuery) query = query.IgnoreQueryFilters();

            return (Task<IQueryable<T>>)(isTracking ? query : query.AsNoTracking());
        }

        public IQueryable<T> GetAllAsync(
            Expression<Func<T, object>>? orderExpression = null,
            int skip = 0, int take = 0,
            bool isTracking = true,
            bool isDescending = false, params string[] includes)
        {
            var query = _table.AsQueryable();


            if (orderExpression is not null)
            {
                if (isDescending) query = query.OrderByDescending(orderExpression);

                else query = query.OrderBy(orderExpression);
            }

            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (skip > 0) query = query.Skip(skip);

            if (take > 0) query = query.Take(take);

            return isTracking ? query : query.AsNoTracking();
        }


        public async Task<IQueryable<T>> GetAllAsync(
            Expression<Func<T, bool>>? expression = null,
            params string[] includes)
        {
            var query =  _table.AsQueryable();


            if (expression is not null) query = query.Where(expression);


            query = _AddIncludes(query,includes);
            return query;
        }


        public async Task<T> GetByIdAsync(int id, bool isTracking = true, bool ignoreQuery = false, params string[] includes)
        {
            IQueryable<T> query = _table.Where(q=>q.Id==id);

            query = _AddIncludes(query,includes);

            if (!isTracking) query = query.AsNoTracking();
            if (ignoreQuery) query = query.IgnoreQueryFilters();

            return await query.FirstOrDefaultAsync();
        }


        public async Task<T> GetByExpressionAsync(Expression<Func<T,bool>> expression, bool isTracking = true, bool ignoreQuery = false, params string[] includes)
        {
            IQueryable<T> query = _table.Where(expression);

            query = _AddIncludes(query, includes);

            if (!isTracking) query = query.AsNoTracking();
            if (ignoreQuery) query = query.IgnoreQueryFilters();

            return await query.FirstOrDefaultAsync();
        }


        public void Update(T entity)
        {
            _table.Update(entity);
        }



        //Remove
        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public void SoftDelete(T entity)
        {
            entity.IgnoreQuery = true;
            _table.Update(entity);
        }

        public void ReverseSoftDelete(T entity)
        {
            entity.IgnoreQuery = false;
        }

        



        public Task<bool> IsExistAsync(Expression<Func<T,bool>> expression, bool ignoreQuery = false)
        {
            return ignoreQuery ? _table.AnyAsync(expression) : _table.IgnoreQueryFilters().AnyAsync(expression);
        }



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        private IQueryable<T> _AddIncludes(IQueryable<T> query, params string[] includes)
        {
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        } 
    }
}

using Microsoft.EntityFrameworkCore;
using NB.SupportPackages.DataBase.Base;
using NB.SupportPackages.DataBase.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NB.SupportPackages.DataBase.Implementation
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T : EntityBase
    {
        private readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public T Add(T Entity)
        {

            var retorno = _context.Set<T>().Add(Entity);
            //_context.SaveChanges();
            return retorno.Entity;
        }

        public async Task<T> AddAsync(T Entity)
        {
            var EntityReturn = await _context.Set<T>().AddAsync(Entity);
            //await _context.SaveChangesAsync();
            return EntityReturn.Entity;
        }

        public void AddRange(IEnumerable<T> Entity)
        {
            _context.Set<T>().AddRange(Entity);
            //_context.SaveChanges();
        }

        public async Task AddRangeAsync(IEnumerable<T> Entity)
        {
            await _context.Set<T>().AddRangeAsync(Entity);
            //await _context.SaveChangesAsync();
        }

        public T Delete(T Entity)
        {
            Entity.Active = false;
            var EntityReturn = _context.Set<T>().Update(Entity);
            //_context.SaveChanges();
            return EntityReturn.Entity;
        }

        public void DeleteRange(IEnumerable<T> Entity)
        {
            Entity.All(e => { e.Active = false; return true; });
            _context.Set<T>().UpdateRange(Entity);
            //_context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> predicate, bool NoLock = true, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return queryable.WithHint(SqlServerHints.NOLOCK).FirstOrDefault(predicate);
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool NoLock = true, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return await queryable.WithHint(SqlServerHints.NOLOCK).FirstOrDefaultAsync(predicate).ConfigureAwait(false);
        }


        public T Update(T Entity)
        {
            var EntityReturn = _context.Set<T>().Update(Entity);
            //_context.SaveChanges();
            return EntityReturn.Entity;
        }


        public void UpdateRange(IEnumerable<T> Entity)
        {
            _context.Set<T>().UpdateRange(Entity);
            //_context.SaveChanges();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool NoLock = true, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return queryable.WithHint(SqlServerHints.NOLOCK).Where(predicate);
        }

        public async Task<ICollection<T>> WhereAsync(Expression<Func<T, bool>> predicate, bool NoLock = true, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = _context.Set<T>();

            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }
            return await queryable.WithHint(SqlServerHints.NOLOCK).Where(predicate).ToListAsync().ConfigureAwait(false);

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

    }
}

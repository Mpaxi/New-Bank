using NB.SupportPackages.DataBase.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NB.SupportPackages.DataBase.Contract
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        IQueryable<T> Where(Expression<Func<T, bool>> predicate, bool NoLock = true, params Expression<Func<T, object>>[] includeProperties);
        Task<ICollection<T>> WhereAsync(Expression<Func<T, bool>> predicate, bool NoLock = true, params Expression<Func<T, object>>[] includeProperties);
        T Get(Expression<Func<T, bool>> predicate, bool NoLock = true, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, bool NoLock = true, params Expression<Func<T, object>>[] includeProperties);
        T Add(T Entity);
        Task<T> AddAsync(T Entity);
        void AddRange(IEnumerable<T> Entity);
        Task AddRangeAsync(IEnumerable<T> Entity);
        T Update(T Entity);
        void UpdateRange(IEnumerable<T> Entity);
        T Delete(T Entity);
        void DeleteRange(IEnumerable<T> Entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}

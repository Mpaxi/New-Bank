using NB.CheckingAccount.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NB.CheckingAccount.Domain.Contract
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        T Add(T Entity);
        Task<T> AddAsync(T Entity);
        void AddRange(IEnumerable<T> Entity);
        Task AddRangeAsync(IEnumerable<T> Entity);
        T Update(T Entity);
        void UpdateRange(IEnumerable<T> Entity);
        T Delete(T Entity);
        void DeleteRange(IEnumerable<T> Entity);
    }
}

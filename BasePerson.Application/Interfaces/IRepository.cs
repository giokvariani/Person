using BasePerson.Model.BusinessObjects;
using System.Linq.Expressions;

namespace BasePerson.Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BusinessObject
    {
        Task<int> CreateAsync(TEntity entity);
        Task<int> CreaRangeteAsync(IEnumerable<TEntity> entity);
        Task<TEntity> ReadAsync(int id);
        Task<IEnumerable<TEntity>> ReadAsync();
        Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> UpdateAsync(int id, TEntity entity);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(TEntity entity);
        Task<int> DeleteRangeAsync(IEnumerable<TEntity> entity);
        Task<bool> CheckAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
    }
}

using Bdaya.Net.Responses.Cotracts.Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bdaya.Net.Repositories.UnitOfWork
{
    public interface IRepository<TEntity,TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        Task<PaginatedResponse<TEntity>> GetPaginatedListAsync(int pageIndex, int pageSize);
        Task<IEnumerable<TEntity>> GetTrash();
        void Deactivate(TEntity entity);
        void DeactivateRange(IEnumerable<TEntity> entities);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        Task<IList<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(TKey Id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

    }
}

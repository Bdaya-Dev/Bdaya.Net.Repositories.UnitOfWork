using Bdaya.Net.Responses.Cotracts.Containers;
using Bdaya.Net.Responses.Processors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bdaya.Net.Repositories.UnitOfWork
{
    public class Repository<TEntity,TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct,IEquatable<TKey>
 
    {
        public DbSet<TEntity> Table { get; set; }
        public Repository(DbContext db)
        {
            Table = db.Set<TEntity>();
        }
        public async Task<IList<TEntity>> GetAllAsync() => await Table.AsNoTracking().ToListAsync();
        public async Task AddAsync(TEntity entity) => await Table.AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await Table.AddRangeAsync(entities);
        public void Delete(TEntity entity) => Table.Remove(entity);
        public void DeleteRange(IEnumerable<TEntity> entities) => Table.RemoveRange(entities);

        public async Task<TEntity> GetByIdAsync(TKey Id)
            => await Table.FirstOrDefaultAsync(x => x.Id.Equals(Id));

        public void Update(TEntity entity) => Table.Update(entity);

        public void UpdateRange(IEnumerable<TEntity> entities) => Table.UpdateRange(entities);

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression) => Table.AsNoTracking().Where(expression);

        public void Deactivate(TEntity entity)
        {
            entity.IsActive = false;
            Table.Update(entity);
        }

        public void DeactivateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsActive = false;
            }
            Table.UpdateRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetTrash()
            => await Table.AsNoTracking().Where(x => x.IsActive == false).ToListAsync();

        public async Task<PaginatedResponse<TEntity>> GetPaginatedListAsync(int pageIndex = 1, int pageSize = 30)
            => await PaginatedList<TEntity>.CreateAsync(Table.Where(x => x.IsActive == true), pageIndex, pageSize);
    }
}

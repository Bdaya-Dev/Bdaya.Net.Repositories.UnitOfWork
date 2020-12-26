using Bdaya.Net.Repositories.UnitOfWork.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdaya.Net.Repositories.UnitOfWork.Units
{
    public class GuidUnitOfWork<TEntity> : IGuidUnitOfWork<TEntity>
     where TEntity : class, IEntity<Guid>
    {
        private readonly DbContext _db;
        public GuidRepos<TEntity> Repos{ get; }


        public GuidUnitOfWork(DbContext db)
        {
            _db = db;
            Repos = new GuidRepos<TEntity>(db);
        }


        public async Task<bool> Commit() => await _db.SaveChangesAsync() > 0;

        public void Dispose() => _db.Dispose();
    }

    public interface IStringUnitOfWork<TEntity>
    {

        Task<bool> Commit();

        void Dispose();
    }
}

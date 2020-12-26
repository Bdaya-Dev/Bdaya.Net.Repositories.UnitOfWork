using Bdaya.Net.Repositories.UnitOfWork.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Bdaya.Net.Repositories.UnitOfWork.Units
{
    public class StringUnitOfWork<TEntity> : IStringUnitOfWork<TEntity>
     where TEntity : class, IStringEntity
    {
        private readonly DbContext _db;
        public StringRepos<TEntity> Repos { get; }


        public StringUnitOfWork(DbContext db)
        {
            _db = db;
            Repos = new StringRepos<TEntity>(db);
        }


        public async Task<bool> Commit() => await _db.SaveChangesAsync() > 0;

        public void Dispose() => _db.Dispose();
    }

    public interface IStringUnitOfWork<TEntity>
             where TEntity : class, IStringEntity
    {

        Task<bool> Commit();

        void Dispose();
    }
}

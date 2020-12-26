using Bdaya.Net.Repositories.UnitOfWork.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdaya.Net.Repositories.UnitOfWork.Units
{
    public class IntUnitOfWork<TEntity> : IIntUnitOfWork<TEntity>
     where TEntity : class, IEntity<int>
    {
        private readonly DbContext _db;
        public IntRepos<TEntity> Repository { get; }


        public IntUnitOfWork(DbContext db)
        {
            _db = db;
            Repository = new IntRepos<TEntity>(db);
        }


        public async Task<bool> Commit() => await _db.SaveChangesAsync() > 0;

        public void Dispose() => _db.Dispose();
    }

    public interface IIntUnitOfWork<TEntity>
    {

        Task<bool> Commit();

        void Dispose();
    }
}

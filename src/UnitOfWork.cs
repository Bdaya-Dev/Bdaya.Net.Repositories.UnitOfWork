using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdaya.Net.Repositories.UnitOfWork
{
    public class UnitOfWork<TEntity,TKey> : IUnitOfWork<TEntity,TKey>
        where TEntity : class, IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        private readonly DbContext _db;
        public Repository<TEntity,TKey> Repository { get; }


        public UnitOfWork(DbContext db)
        {
            _db = db;
            Repository = new Repository<TEntity,TKey>(db);
        }


        public async Task<bool> Commit() => await _db.SaveChangesAsync() > 0;

        public void Dispose() => _db.Dispose();
    }
}

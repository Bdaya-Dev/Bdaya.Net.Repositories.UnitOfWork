using System;
using System.ComponentModel.DataAnnotations;

namespace Bdaya.Net.Repositories.UnitOfWork
{
    public interface IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        public bool IsActive { get; set; }
    }
}

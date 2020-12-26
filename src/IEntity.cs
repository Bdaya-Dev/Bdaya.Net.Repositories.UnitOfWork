using System;
using System.ComponentModel.DataAnnotations;

namespace Bdaya.Net.Repositories.UnitOfWork
{
    public interface IEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        public bool IsActive { get; set; }
    }

    public interface IEntity
    {
        [Key]
        public string Id { get; set; }
        public bool IsActive { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Bdaya.Net.Repositories.UnitOfWork
{
    public interface IGuidEntity
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }

    public interface IIntEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }

    public interface IStringEntity
    {
        [Key]
        public string Id { get; set; }
        public bool IsActive { get; set; }
    }

}

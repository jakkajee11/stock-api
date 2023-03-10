using System;
namespace StockApi.Entities
{
    public class EntityBase
    {
        public virtual Guid Id { get; set; }
        public virtual bool Deleted { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
    }
}


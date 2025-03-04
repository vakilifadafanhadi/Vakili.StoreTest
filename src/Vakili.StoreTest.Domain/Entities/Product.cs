using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Vakili.StoreTest.Entities
{
    public class Product : Entity<Guid>
    {
        public string Title { get; set; }
        public Guid? ParentId { get; set; }
        public virtual Product? Parent { get; set; }
        public byte Level { get; set; } = 0;
        public virtual ICollection<Product> Children { get; set; } = [];
    }
}

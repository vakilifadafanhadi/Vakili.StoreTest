using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Vakili.StoreTest.Entities
{
    public class OperationLog : AuditedAggregateRoot<Guid>
    {
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string Description { get; set; }
    }
}

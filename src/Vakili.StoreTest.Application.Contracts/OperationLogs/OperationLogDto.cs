using System;
using Vakili.StoreTest.Users;
using Volo.Abp.Application.Dtos;

namespace Vakili.StoreTest.OperationLogs
{
    public class OperationLogDto : AuditedEntityDto<Guid>
    {
        public string Description { get; set; }
        public CompactedUserDto? Creator { get; set; }
    }
}

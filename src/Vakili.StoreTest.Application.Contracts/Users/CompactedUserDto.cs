using System;
using Volo.Abp.Application.Dtos;

namespace Vakili.StoreTest.Users
{
    public class CompactedUserDto : EntityDto<Guid>
    {
        public string UserName { get; set; }
    }
}

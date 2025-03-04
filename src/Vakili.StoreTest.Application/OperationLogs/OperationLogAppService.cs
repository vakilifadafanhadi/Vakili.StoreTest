using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vakili.StoreTest.Entities;
using Vakili.StoreTest.Users;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;

namespace Vakili.StoreTest.OperationLogs
{
    public class OperationLogAppService(
        IRepository<OperationLog, Guid> repository,
        IIdentityUserRepository identityUserRepository
        ) : 
        CrudAppService<
            OperationLog,
            OperationLogDto,
            Guid,
            PagedResultRequestDto,
            CreateOperationLogDto>(repository), IOperationLogAppService
    {
        private readonly IIdentityUserRepository _identityUserRepository = identityUserRepository;
        public override async Task<PagedResultDto<OperationLogDto>> GetListAsync(PagedResultRequestDto input)
        {
            var result = await base.GetListAsync(input);
            var userIds = result.
                Items.
                Where(log => log.CreatorId.HasValue).
                Select(log => log.CreatorId!.Value).
                Distinct().
                ToList();
            var users = await _identityUserRepository.GetListByIdsAsync(userIds);
            var usersDto = ObjectMapper.Map<IList<IdentityUser>, IList<CompactedUserDto>>(users);
            foreach (var log in result.Items)
                log.Creator = usersDto.Single(user => user.Id == log.CreatorId);
            return result;
        }
    }
}

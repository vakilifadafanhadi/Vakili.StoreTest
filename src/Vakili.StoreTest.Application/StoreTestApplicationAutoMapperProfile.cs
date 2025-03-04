using AutoMapper;
using Vakili.StoreTest.Users;
using Volo.Abp.Identity;

namespace Vakili.StoreTest;

public class StoreTestApplicationAutoMapperProfile : Profile
{
    public StoreTestApplicationAutoMapperProfile()
    {
        CreateMap<IdentityUser, CompactedUserDto>();
    }
}

using Vakili.StoreTest.Samples;
using Xunit;

namespace Vakili.StoreTest.EntityFrameworkCore.Domains;

[Collection(StoreTestTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<StoreTestEntityFrameworkCoreTestModule>
{

}

using Vakili.StoreTest.Samples;
using Xunit;

namespace Vakili.StoreTest.EntityFrameworkCore.Applications;

[Collection(StoreTestTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<StoreTestEntityFrameworkCoreTestModule>
{

}

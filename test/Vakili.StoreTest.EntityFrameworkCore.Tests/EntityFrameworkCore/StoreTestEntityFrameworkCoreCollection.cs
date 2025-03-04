using Xunit;

namespace Vakili.StoreTest.EntityFrameworkCore;

[CollectionDefinition(StoreTestTestConsts.CollectionDefinitionName)]
public class StoreTestEntityFrameworkCoreCollection : ICollectionFixture<StoreTestEntityFrameworkCoreFixture>
{

}

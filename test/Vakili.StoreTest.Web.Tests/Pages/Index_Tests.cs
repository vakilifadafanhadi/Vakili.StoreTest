using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Vakili.StoreTest.Pages;

[Collection(StoreTestTestConsts.CollectionDefinitionName)]
public class Index_Tests : StoreTestWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

using Microsoft.AspNetCore.Builder;
using Vakili.StoreTest;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("Vakili.StoreTest.Web.csproj"); 
await builder.RunAbpModuleAsync<StoreTestWebTestModule>(applicationName: "Vakili.StoreTest.Web");

public partial class Program
{
}

using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Vakili.StoreTest.OperationLogs
{
    public interface IOperationLogAppService : ITransientDependency, IRemoteService
    {
        Task<OperationLogDto> CreateAsync(CreateOperationLogDto input);
    }
}

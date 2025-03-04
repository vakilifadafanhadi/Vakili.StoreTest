using AutoMapper;
using Vakili.StoreTest.Entities;

namespace Vakili.StoreTest.OperationLogs
{
    public class OperationLogAutoMapperProfile : Profile
    {
        public OperationLogAutoMapperProfile()
        {
            CreateMap<CreateOperationLogDto, OperationLog>();
            CreateMap<OperationLog, OperationLogDto>()
                .ForMember(dst => dst.Description, opt => opt.MapFrom(src => _calculateDescription(src)));
        }
        internal string _calculateDescription(OperationLog operationLog)
        {
            string type = (operationLog.NewValue is not null && operationLog.OldValue is null) ? "Create" : ((operationLog.NewValue is not null && operationLog.OldValue is not null) ? "Update" : "Delete");
            
            string result = type + operationLog.Description + type switch
            {
                "Create" => operationLog.NewValue,
                "Update" => operationLog.OldValue + "to" + operationLog.NewValue,
                "Delete" => operationLog.OldValue,
                _ => "undefined"
            };
            return result;
        }
    }
}

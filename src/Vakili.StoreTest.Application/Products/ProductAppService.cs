using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Vakili.StoreTest.Entities;
using Vakili.StoreTest.OperationLogs;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Vakili.StoreTest.Products
{
    public class ProductAppService(
        IRepository<Product, Guid> repository,
        IOperationLogAppService operationLogAppService) : 
        CrudAppService<
            Product,
            ProductDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateProductDto>(repository)
    {
        private readonly IOperationLogAppService _operationLogAppService = operationLogAppService;
        public override async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            var operationLogDto = new CreateOperationLogDto
            {
                Description = nameof(Product),
                NewValue = input.Title
            };
            await _operationLogAppService.CreateAsync(operationLogDto);
            Product product = new()
            {
                Title = input.Title,
                ParentId = input.ParentId
            };
            if (input.ParentId.HasValue)
            {
                var parent = await Repository.GetAsync(input.ParentId.Value);
                product.Level = (byte)(parent.Level + 1);
            }
            //در لایه دیتابیس چک شده است که بیش از 4 لایه نشود. اما به خاطر خطای کاربر پسند، در لایه اپلیکیشن هم چک می شود
            if (product.Level >= 4)
                throw new UserFriendlyException("you cannot create more than 4 layers");
            await Repository.InsertAsync(product);
            return await MapToGetOutputDtoAsync(product);
        }
        public override async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var product = await Repository.GetAsync(id);
            await MapToEntityAsync(input, product);
            var operationLogDto = new CreateOperationLogDto
            {
                Description = nameof(product),
                NewValue = input.Title,
                OldValue = product.Title
            };
            await _operationLogAppService.CreateAsync(operationLogDto);
            if (input.ParentId.HasValue)
            {
                var parent = await Repository.GetAsync(input.ParentId.Value);
                product.Level = (byte)(parent.Level + 1);
            }
            await Repository.UpdateAsync(product);
            return await MapToGetOutputDtoAsync(product);
        }
        public override async Task DeleteAsync(Guid id)
        {
            var product = await Repository.GetAsync(id);
            await Repository.EnsureCollectionLoadedAsync(product, p => p.Children);
            if (product.Children.Any())
                throw new UserFriendlyException("You should delete its children first");
            var operationLogDto = new CreateOperationLogDto
            {
                Description = nameof(product),
                OldValue = product.Title
            };
            await _operationLogAppService.CreateAsync(operationLogDto);
            await base.DeleteAsync(id);
        }
        public async Task<IList<ProductDto>> GetListTreeAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var flatList = await AsyncExecuter.ToListAsync(query);
            var flatListDto = await MapToGetListOutputDtosAsync(flatList);
            var roots = flatListDto.
                Where(product => !product.ParentId.HasValue).
                ToList();
            foreach (var item in roots)
            {
                item.Children = flatListDto.
                    Where(product => product.ParentId == item.Id).
                    ToList();
            }
            return roots;
        }
    }
}

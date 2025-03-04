using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Vakili.StoreTest.Products
{
    public sealed class ProductDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public Guid? ParentId { get; set; }
        public IList<ProductDto> Children { get; set; } = [];
    }
}

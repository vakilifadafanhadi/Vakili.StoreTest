using AutoMapper;
using Vakili.StoreTest.Entities;

namespace Vakili.StoreTest.Products
{
    public class ProductAutoMapperProfile : Profile
    {
        public ProductAutoMapperProfile()
        {
            CreateMap<CreateUpdateProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}

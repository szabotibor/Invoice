using AutoMapper;
using Product.Application.Dto;
using Product.Domain.Entity;

namespace Product.Application.Mapping
{
    public class ProductMapping: Profile
    {
        public ProductMapping()
        {
            CreateMap<AddProductDto, Domain.Entity.Product>();
            CreateMap<ProductDto, Domain.Entity.Product>().ReverseMap();
        }
    }
}
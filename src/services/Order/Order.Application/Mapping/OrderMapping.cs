using AutoMapper;
using Order.Application.Dto;
using Order.Domain.Entity;

namespace Order.Application.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<AddOrderDto, Domain.Entity.Order>();
            CreateMap<AddOrderItemDto, OrderItem>();
        }
    }
}
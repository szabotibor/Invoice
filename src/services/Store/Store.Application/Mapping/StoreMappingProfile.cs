using AutoMapper;
using Store.Application.Dto;

namespace Store.Application.Mapping
{
    public class StoreMappingProfile : Profile
    {
        public StoreMappingProfile()
        {
            CreateMap<StoreDto, Domain.Entity.Store>().ReverseMap();
            CreateMap<AddStorePayload, Domain.Entity.Store>();
            CreateMap<UpdateStorePayload, Domain.Entity.Store>();
        }
    }
}
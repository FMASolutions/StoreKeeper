using AutoMapper;
using StoreKeeper.Services.DTOs;
using StoreKeeper.Core.Models;

namespace StoreKeeper.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<ProductGroup, ProductGroupDTO>();
            CreateMap<ProductGroup, ProductGroupPreviewDTO>();
            CreateMap<SubGroup, SubGroupDTO>();
            CreateMap<SubGroup, SubGroupPreviewDTO>();
            
            // Resource to Domain
            CreateMap<ProductGroupDTO, ProductGroup>();
            CreateMap<ProductGroupPreviewDTO, ProductGroup>();
            CreateMap<ProductGroupSaveDTO, ProductGroup>();
            CreateMap<SubGroupDTO, SubGroup>();
            CreateMap<SubGroupPreviewDTO, SubGroup>();
            CreateMap<SubGroupSaveDTO, SubGroup>();
        }
    }
}

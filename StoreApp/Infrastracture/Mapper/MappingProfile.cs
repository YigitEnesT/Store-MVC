using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastracture.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDtoForInsertion,Product>();
            CreateMap<ProductDtoForUpdate,Product>().ReverseMap();
        }
    }
}
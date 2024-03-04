using AutoMapper;
using ProductsManagement.Api.DataTransferObjects;
using ProductsManagement.Api.ExternalServicesAdapters;
using ProductsManagement.ApplicationCore.Entities;

namespace ProductsManagement.Api.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => new StatusAdapter().GetStatusProduct(src.Status)));
        }
    }
}

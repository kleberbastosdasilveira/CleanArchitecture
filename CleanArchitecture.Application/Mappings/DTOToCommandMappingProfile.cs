using AutoMapper;
using CleanArchitecture.Application.CQRS.Products.Command;
using CleanArchitecture.Application.DTOs;

namespace CleanArchitecture.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}

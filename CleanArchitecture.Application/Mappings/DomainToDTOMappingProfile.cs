using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.DTOs.Address;
using CleanArchitecture.Application.DTOs.Category.DTO;
using CleanArchitecture.Application.DTOs.Product.DTO;
using CleanArchitecture.Application.DTOs.User;
using CleanArchitecture.Application.DTOs.User.DTO;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryDeteilDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Product, ProductDetailDTO>().ReverseMap();
            CreateMap<Product, ProductEditDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
        }
    }
}

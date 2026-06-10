using AutoMapper;
using RestAPIProject.DTOs;
using RestAPIProject.Models;

namespace RestAPIProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();

            CreateMap<CreateProductDto, Product>();

            CreateMap<UpdateProductDto, Product>();
        }
    }
}

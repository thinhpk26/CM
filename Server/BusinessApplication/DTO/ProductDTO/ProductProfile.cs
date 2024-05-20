using AutoMapper;
using Repo.Entities;

namespace BusinessApplication.DTO.ProductDTO
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductGetDTO>();
            CreateMap<ProductInsertDTO, Product>();
            CreateMap<ProductUpdateDTO, Product>();
        }
    }
}

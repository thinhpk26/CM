using AutoMapper;
using Repo.Entities;

namespace BusinessApplication.DTO.PricebookDTO
{
    public class PricebookProfile : Profile
    {
        public PricebookProfile()
        {
            CreateMap<Pricebook, PricebookGetDTO>();
            CreateMap<PricebookInsertDTO, Pricebook>();
            CreateMap<PricebookUpdateDTO, Pricebook>();
        }
    }
}

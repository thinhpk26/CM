using AutoMapper;
using Repo.Entities;

namespace BusinessApplication.DTO.LeadDTO
{
    public class LeadProfile : Profile
    {
        public LeadProfile()
        {
            CreateMap<Lead, LeadGetDTO>();
            CreateMap<Lead, AccountInsertDTO>();
            CreateMap<LeadInsertDTO, Lead>();
            CreateMap<LeadUpdateDTO, Lead>();
        }
    }
}

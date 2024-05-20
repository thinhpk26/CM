using Repo.Entities;
using AutoMapper;
using Repo.Context;

namespace AuthAppication.DTO.CompanyDTO
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyGetDTO>();
            CreateMap<CompanyInsertDTO, Company>();
            CreateMap<CompanyUpdateDTO, Company>();
            CreateMap<Company, CompanyContext>();
        }
    }
}

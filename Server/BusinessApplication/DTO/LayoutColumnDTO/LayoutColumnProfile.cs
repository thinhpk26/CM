using AutoMapper;
using Repo.Context;
using Repo.Entities;

namespace BusinessApplication.DTO
{
    public class LayoutColumnProfile : Profile
    {
        public LayoutColumnProfile()
        {
            CreateMap<LayoutColumn, LayoutColumnGetDTO>();
            CreateMap<LayoutColumnUpdateDTO, LayoutColumn>();
        }
    }
}

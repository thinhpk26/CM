using AutoMapper;
using Repo.Context;
using Repo.Entities;

namespace AuthAppication.DTO
{
    public class ConfirmCodeProfile : Profile
    {
        public ConfirmCodeProfile()
        {
            CreateMap<Repo.Entities.ConfirmCode, ConfirmCode.ConfirmCodeGetDTO>();
        }
    }
}

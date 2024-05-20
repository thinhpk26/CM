using Repo.Entities;
using AutoMapper;

namespace AuthAppication.DTO
{
    public class UserPlatFormProfile : Profile
    {
        public UserPlatFormProfile()
        {
            CreateMap<UserPlatForm, UserPlatFormGetDTO>();
            CreateMap<UserPlatFormInsertDTO, UserPlatForm>();
            CreateMap<UserPlatFormUpdateDTO, UserPlatForm>();
        }
    }
}

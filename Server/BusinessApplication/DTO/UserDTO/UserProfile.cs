using AutoMapper;
using Repo.Entities;
using Repo.Context;

namespace BusinessApplication.DTO
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserContext>();
            CreateMap<User, UserGetDTO>();
            CreateMap<UserInsertDTO, User>();
            CreateMap<UserUpdateDTO, User>();
        }
    }
}

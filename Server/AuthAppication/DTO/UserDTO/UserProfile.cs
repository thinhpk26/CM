using AutoMapper;
using Repo.Entities;
using Repo.Context;

namespace AuthAppication.DTO.UserDTO
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserContext>();
        }
    }
}

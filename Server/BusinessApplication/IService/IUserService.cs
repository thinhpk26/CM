using Application.IService;
using BusinessApplication.DTO;
using Repo.Entities;

namespace BusinessApplication.IService
{
    public interface IUserService : IBaseService<User, UserGetDTO, UserInsertDTO, UserUpdateDTO>
    {
    }
}

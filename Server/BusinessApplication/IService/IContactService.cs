using Application.IService;
using BusinessApplication.DTO;
using Repo.Entities;

namespace BusinessApplication.IService
{
    public interface IContactService : IBaseService<Contact, ContactGetDTO, ContactInsertDTO, ContactUpdateDTO>
    {
    }
}

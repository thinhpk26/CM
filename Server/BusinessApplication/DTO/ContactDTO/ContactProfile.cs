using AutoMapper;
using Repo.Entities;

namespace BusinessApplication.DTO.ContactDTO
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactGetDTO>();
            CreateMap<ContactInsertDTO, Contact>();
            CreateMap<ContactUpdateDTO, Contact>();
        }
    }
}

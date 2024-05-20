using Application.Service;
using AutoMapper;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using BusinessRepo.IRepo;
using Repo.Context;
using Repo.Entities;
using Repo.IRepo;
using Repo.UnitOfWork;

namespace BusinessApplication.Service
{
    public class ContactService : BaseService<Contact, ContactGetDTO, ContactInsertDTO, ContactUpdateDTO>, IContactService
    {
        protected override string LayoutCode { get => "Contact"; }
        public ContactService(IContactRepo repo, IMapper mapper, ICMHttpContext context, IUnitOfWork unitOfWork) : base(repo, mapper, context, unitOfWork)
        {
        }
    }
}

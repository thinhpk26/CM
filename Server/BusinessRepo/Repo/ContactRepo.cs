using BusinessRepo.IRepo;
using Repo.Context;
using Repo.Entities;
using Repo.UnitOfWork;

namespace BusinessRepo.Repo
{
    public class ContactRepo : BusinessBaseRepo<Contact>, IContactRepo
    {
        public ContactRepo(IConfiguration config, ICMHttpContext context, IUnitOfWork unitOfWork) : base(config, context, unitOfWork)
        {
        }
    }
}

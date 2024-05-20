using Repo.Entities;
using Repo.IRepo;
using Repo.Context;
using Repo.Repo;
using Repo.UnitOfWork;
using BusinessRepo.IRepo;

namespace BusinessRepo.Repo
{
    public class AccountRepo : BusinessBaseRepo<Account>, IAccountRepo
    {
        public AccountRepo(IConfiguration config, ICMHttpContext context, IUnitOfWork unitOfWork) : base(config, context, unitOfWork)
        {
        }
    }
}

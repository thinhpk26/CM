using Repo.Entities;
using BusinessRepo.IRepo;
using Repo.Context;
using Repo.UnitOfWork;
using Repo.Models;
using Dapper;

namespace BusinessRepo.Repo
{
    public class UserRepo : BusinessBaseRepo<User>, IUserRepo
    {
        public UserRepo(IConfiguration config, ICMHttpContext context, IUnitOfWork unitOfWork) : base(config, context, unitOfWork)
        {
        }
    }
}

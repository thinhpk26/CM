using BusinessRepo.IRepo;
using BusinessRepo.Repo;
using Repo.Context;
using Repo.Entities;
using Repo.UnitOfWork;

namespace BusinessRepo.Models
{
    public class LeadRepo : BusinessBaseRepo<Lead>, ILeadRepo
    {
        public LeadRepo(IConfiguration config, ICMHttpContext context, IUnitOfWork unitOfWork) : base(config, context, unitOfWork)
        {
        }
    }
}

using Repo.Entities;
using BusinessRepo.IRepo;
using Repo.IRepo;

namespace BusinessRepo.IRepo
{
    public interface IAccountRepo : IBusinessBaseRepo<Account>
    {
    }
}

using Repo.Entities;
using Repo.IRepo;

namespace AuthRepo.IRepos
{
    public interface IConfirmCodeRepo : IBaseRepo<ConfirmCode>
    {
        /// <summary>
        /// Lấy bản ghi theo code
        /// </summary>
        /// <returns></returns>
        public Task<ConfirmCode> GetConfirmCodeByCode(Guid code);
    }
}

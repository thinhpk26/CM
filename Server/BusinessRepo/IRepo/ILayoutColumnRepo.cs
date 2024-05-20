using BusinessRepo.Repo;
using Repo.Entities;

namespace BusinessRepo.IRepo
{
    public interface ILayoutColumnRepo : IBusinessBaseRepo<LayoutColumn>
    {
        /// <summary>
        /// Lấy danh sách column theo layoutCode
        /// </summary>
        /// <param name="LayoutCode"></param>
        /// <returns></returns>
        public Task<List<LayoutColumn>> GetColumnsByLayoutCode(string LayoutCode);
    }
}

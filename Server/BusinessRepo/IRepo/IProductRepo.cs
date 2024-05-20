using BusinessRepo.Models;
using BusinessRepo.Repo;
using Repo.Entities;
using Repo.Models;

namespace BusinessRepo.IRepo
{
    public interface IProductRepo : IBusinessBaseRepo<Product>
    {
        /// <summary>
        /// Lấy product đã áp dụng chính sách giá
        /// </summary>
        /// <param name="pagingParameter"></param>
        /// <returns></returns>
        public Task<List<ProductApplyPricebook>> ProductApplyPricebook(string? id);
    }
}

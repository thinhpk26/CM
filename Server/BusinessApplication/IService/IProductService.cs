using Application.IService;
using BusinessApplication.DTO;
using BusinessRepo.Models;
using Repo.Entities;
using Repo.Models;

namespace BusinessApplication.IService
{
    public interface IProductService : IBaseService<Product, ProductGetDTO, ProductInsertDTO, ProductUpdateDTO>
    {
        /// <summary>
        /// Apply chính sách giá
        /// </summary>
        /// <param name="pagingParameter"></param>
        /// <returns></returns>
        public Task<List<ProductApplyPricebook>> ProductApplyPricebook(string? ids);
    }
}

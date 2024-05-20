using Repo.Entities;

namespace BusinessRepo.IRepo
{
    public interface IOrderRepo : IBusinessBaseRepo<Order>
    {
        /// <summary>
        /// Lưu vào bảng mapping
        /// </summary>
        /// <param name="productMapping"></param>
        /// <returns></returns>
        public Task<int> InsertProductMapping(List<OrderProductMapping>? productMapping);
    }
}

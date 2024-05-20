using Repo.Entities;

namespace BusinessRepo.IRepo
{
    public interface IPricebookRepo : IBusinessBaseRepo<Pricebook>
    {
        /// <summary>
        /// Insert thêm product mapping
        /// </summary>
        /// <param name="productMapping"></param>
        /// <returns></returns>
        public Task<int> InsertProductMapping(List<PricebookProductMapping>? productMapping);

        /// <summary>
        /// Insert thêm product mapping
        /// </summary>
        /// <param name="productMapping"></param>
        /// <returns></returns>
        public Task<int> UpdateProductMapping(long pricebookID, List<PricebookProductMapping>? productMapping);
    }
}

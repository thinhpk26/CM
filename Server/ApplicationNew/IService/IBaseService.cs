using Repo.Models;

namespace Application.IService
{
    public interface IBaseService<T, TGet, TInsert, TUpdate>
    {
        /// <summary>
        /// Lấy bản ghi theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TGet> GetEntityByID(long id);

        public Task<T> GetEntityByEntityCode(string code);
        /// <summary>
        /// Lấy danh sách bản ghi theo điều kiện paging
        /// </summary>
        /// <param name="pagingParameter"></param>
        /// <returns></returns>
        public Task<List<TGet>> GetListEntities(PagingParameter? pagingParameter);

        /// <summary>
        /// Insert bản ghi 
        /// </summary>
        /// <param name="insertEntity"></param>
        /// <returns></returns>
        public Task<TGet> InserEntity(TInsert insertEntity);

        /// <summary>
        /// Insert nhiếu bản ghi
        /// </summary>
        /// <param name="insertEntities"></param>
        /// <returns></returns>
        public Task<int> InsertEntities(List<TInsert> insertEntities);
         
        /// <summary>
        /// Update 1 dòng dữ liệu theo id
        /// </summary>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        public Task<bool> UpdateEntity(long id, TUpdate newEntity);

        /// <summary>
        /// Update 1 dòng dữ liệu theo điều kiện
        /// </summary>
        /// <param name="updateParameter"></param>
        /// <returns></returns>
        public Task<bool> UpdateEntitiesByCondition(UpdateParameter updateParameter);

        /// <summary>
        /// Xóa bản ghi theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> DeleteEntity(long id);

        /// <summary>
        /// Xóa nhiều bản ghi cùng lúc
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public Task<bool> DeleteEntities(List<long> ids);

        /// <summary>
        /// Lấy dữ liệu tổng số
        /// </summary>
        /// <param name="pagingParameter"></param>
        /// <returns></returns>
        public Task<PagingSummary> GetSummary(PagingParameter pagingParameter);
    }
}

using Repo.Models;
using System.Data.Common;

namespace Repo.IRepo
{
    public interface IBaseRepo<T>
    {
        /// <summary>
        /// Lấy tên của bảng
        /// </summary>
        /// <returns></returns>
        public string GetTableName();

        /// <summary>
        /// Lấy các trường của bảng
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, object> GetFields(T entity);

        /// <summary>
        /// Lấy bản ghi theo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T> GetEntityByID(long id);

        public Task<T> GetEntityByEntityCode(string fieldCode, string code);

        /// <summary>
        /// Lấy danh sách bản ghi theo điều kiện paging
        /// </summary>
        /// <param name="pagingParameter"></param>
        /// <returns></returns>
        public Task<List<T>> GetListEntities(PagingParameter? pagingParameter);

        /// <summary>
        /// Lấy danh sách bản ghi theo điều kiện paging
        /// </summary>
        /// <param name="pagingParameter"></param>
        /// <returns></returns>
        public Task<List<T>> GetListEntities(DbConnection cnn, DbTransaction tran, PagingParameter? pagingParameter);

        /// <summary>
        /// Insert bản ghi 
        /// </summary>
        /// <param name="insertEntity"></param>
        /// <returns></returns>
        public Task<int> InserEntity(T entity);

        /// <summary>
        /// Insert bản ghi 
        /// </summary>
        /// <param name="insertEntity"></param>
        /// <returns></returns>
        public Task<int> InserEntity(DbConnection cnn, DbTransaction tran, T entity);

        /// <summary>
        /// Insert nhiều bản ghi 
        /// </summary>
        /// <param name="insertEntity"></param>
        /// <returns></returns>
        public Task<int> InserEntities(List<T> entity);

        /// <summary>
        /// Update 1 dòng dữ liệu theo id
        /// </summary>
        /// <param name="newEntity"></param>
        /// <returns></returns>
        public Task<bool> UpdateEntityByID(T newEntity);

        /// <summary>
        /// Update 1 dòng dữ liệu theo điều kiện
        /// </summary>
        /// <param name="updateParameter"></param>
        /// <returns></returns>
        public Task<int> UpdateEntitiesByCondition(UpdateParameter updateParameter);

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
        public Task<int> DeleteEntities(List<long> ids);

        /// <summary>
        /// Tạo connection string
        /// </summary>
        /// <returns></returns>
        public string BuildCnnString(string dbSave);

        /// <summary>
        /// Lấy tổng số bản ghi trong db
        /// </summary>
        /// <returns></returns>
        public Task<long> GetTotal(PagingParameter pagingParameter);

        /// <summary>
        /// Lấy mã theo layout code
        /// </summary>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public Task<TableCode> GetTableCode(string layoutCode);

        /// <summary>
        /// Lấy toàn bộ code của table
        /// </summary>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public Task<T> GetEntityByCode(string fieldCode, string code);

        /// <summary>
        /// Lưu trữ lại code
        /// </summary>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public Task<int> SaveEntityCode(string layoutCode, int number);
    }
}

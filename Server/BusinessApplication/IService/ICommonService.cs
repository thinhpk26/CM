using BusinessRepo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessApplication.IService
{
    public interface ICommonService 
    {
        /// <summary>
        /// Lấy danh sách phân hệ
        /// </summary>
        /// <returns></returns>
        public Task<List<Layout>> GetLayoutList();

        /// <summary>
        /// Lấy danh sách item trong dictionary by fieldname
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public Task<List<ResponseDictionary>> GetDictionaryByFieldName(string field);

        /// <summary>
        /// Lấy groupbox danh sách theo layoutCode
        /// </summary>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public Task<List<GroupBox>> GetGroupBoxesByLayoutCode(string layoutCode);

        /// <summary>
        /// Lấy Thông tin grid edit
        /// </summary>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public Task<List<GridCell>> GetGridEdit(string layoutCode);
    }
}

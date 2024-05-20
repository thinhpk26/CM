using BusinessRepo.Models;
using Microsoft.AspNetCore.Mvc;

namespace BusinessRepo.IRepo
{
    public interface ICommonRepo
    {
        /// <summary>
        /// Lấy tất cả các phân hệ
        /// </summary>
        /// <returns></returns>
        public Task<List<Layout>> GetLayoutList();

        /// <summary>
        /// Lấy danh sách các item trong dictionary
        /// </summary>
        /// <returns></returns>
        public Task<List<ResponseDictionary>> GetDictionaryByFieldName(string fieldName);

        /// <summary>
        /// Lấy groupbox danh sách theo layoutCode
        /// </summary>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public Task<List<GroupBox>> GetGroupBoxesByLayoutCode(string layoutCode);

        /// <summary>
        /// Lấy thông tin của grid edit
        /// </summary>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public Task<List<GridCell>> GetGridEdit(string layoutCode);
    }
}

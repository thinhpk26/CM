using Application.IService;
using BusinessApplication.DTO;
using Repo.Entities;

namespace BusinessApplication.IService
{
    public interface ILayoutColumnService : IBaseService<LayoutColumn, LayoutColumnGetDTO, LayoutColumnInsertDTO, LayoutColumnUpdateDTO>
    {
        /// <summary>
        /// Lấy thông tin cột theo layout code
        /// </summary>
        /// <param name="layoutCode"></param>
        /// <returns></returns>
        public Task<List<LayoutColumnGetDTO>> GetColumnsByLayoutCode(string layoutCode);
    }
}

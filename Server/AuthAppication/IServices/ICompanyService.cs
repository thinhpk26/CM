using Application.IService;
using Application.Service;
using AuthAppication.DTO.CompanyDTO;
using AuthAppication.DTO;
using AuthRepo.Models;
using Repo.Entities;

namespace AuthAppication.IServices
{
    public interface ICompanyService : IBaseService<Company, CompanyGetDTO, CompanyInsertDTO, CompanyUpdateDTO>
    {
        /// <summary>
        /// Tạo công ty mới
        /// </summary>
        /// <param name="DbSave"></param>
        /// <returns></returns>
        public Task<bool> CreateNewCompany(string DbSave);

        /// <summary>
        /// Lấy tất cả công ty bằng tài khoản người dùng
        /// </summary>
        /// <param name="loginInfor"></param>
        /// <returns></returns>
        public Task<List<CompanyGetDTO>> GetCompanyByAccountPassword(CompanyByAccountPassword loginInfor);


        /// <summary>
        /// Lấy tất cả company của người dùng ID người dùng
        /// </summary>
        /// <param name="infor"></param>
        /// <returns></returns>
        public Task<List<CompanyGetDTO>> GetAllCompanyOfUserByUserID(string userID);


        /// <summary>
        /// Lấy công ty theo confirm code
        /// </summary>
        /// <param name="confirmCode"></param>
        /// <returns></returns>
        public Task<CompanyGetDTO> GetCompanyByConfirmCode(string confirmCode);

        /// <summary>
        /// Lấy người dùng platform theo ID
        /// </summary>
        /// <param name="CompanyCode"></param>
        /// <returns></returns>
        public Task<List<UserPlatForm>> GetUserPlatformByCompanyCode(string companyCode);
    }
}

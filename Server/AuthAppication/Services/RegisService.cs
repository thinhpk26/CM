using AuthAppication.DTO;
using AuthAppication.DTO.CompanyDTO;
using AuthAppication.IServices;
using AuthRepo.IRepos;
using AuthRepo.Models;
using AuthRepo.Repos;
using AutoMapper;
using Business;
using Repo.Context;
using Repo.Entities;
using Repo.Enums;
using Repo.Models;
using Repo.UnitOfWork;
using System.Data.Common;
using System.Text;
using Utility;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AuthAppication.Services
{
    public class RegisService : IRegisService
    {
        private readonly IUserPlatFormRepo _userPlatformRepo;
        private readonly ICompanyService _companySV;
        private readonly IMapper _mapper;
        public readonly ICMHttpContext Context;
        private readonly int NUMBER_COMPANYCODE = 10;
        private readonly IConfirmCodeRepo _confirmRepo;
        private readonly IUserRepo _userRepo;
        private readonly ILoginService _loginSV;
        private readonly ICompanyRepo _companyRepo;
        public readonly IUnitOfWork UnitOfWork;
        public RegisService(IUserPlatFormRepo userPlatformRepo, ICompanyService companySV, ICompanyRepo companyRepo, IMapper mapper, ICMHttpContext context, IConfirmCodeRepo confirmRepo, IUserRepo userRepo, ILoginService loginSV, IUnitOfWork unitOfWork)
        {
            _userPlatformRepo = userPlatformRepo;
            _companyRepo = companyRepo;
            _companySV = companySV;
            _mapper = mapper;
            Context = context;
            _confirmRepo = confirmRepo;
            _userRepo = userRepo;
            _loginSV = loginSV;
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> RegisEmployee(Guid inviteCode, RegisEmployeeModel regisInfor)
        {
            // Lỗi
            var error = new List<string>();
            try
            {
                await UnitOfWork.OpenAsync();
                await UnitOfWork.BeginTransationAsync();
                // Check inviteCode có thỏa mãn không
                var confirmCode = await ValidateConfirmToken(inviteCode);
                // Check người dùng có thỏa mãn không
                var userPlatform = await ValidateUser(error, regisInfor.FullName, regisInfor.Email, regisInfor.Password, regisInfor.NumberPhone, confirmCode.Company);
                // Thêm người dùng vào company
                await AddUserIntoCompany(confirmCode.Company.DBSave, userPlatform, false);
                // Thêm đã sử dụng cho confirmcode
                var updateUsedConfirmCodeParam = new UpdateParameter()
                {
                    EntityUpdate = new Dictionary<string, object>()
                    {
                        ["IsUsed"] = true
                    },
                    NestOperator = NestOperator.AND,
                    Condition = new List<Condition>()
                    {
                        new Condition()
                        {
                            Key = "ID",
                            Value = confirmCode.ID,
                            Operator = Operator.As
                        }
                    },
                };
                await _confirmRepo.UpdateEntitiesByCondition(updateUsedConfirmCodeParam);
                await UnitOfWork.CommitAsync();
            } catch
            {
                await UnitOfWork.RollBackAsync();
                throw;
            } finally
            {
                await UnitOfWork.CloseAsync();
            }
            return true;
        }

        public async Task<bool> RegisNewDomain(RegisNewDomainModel regisInfor)
        {
            // Lỗi
            var error = new List<string>();
            
            try
            {
                await UnitOfWork.OpenAsync();
                await UnitOfWork.BeginTransationAsync();
                var userPlatform = await ValidateUser(error, regisInfor.FullName, regisInfor.Email, regisInfor.Password, regisInfor.NumberPhone);
                // Tạo ra mã db mới
                var companyList = await _companyRepo.GetListEntities(new PagingParameter());
                string DBSave = "";
                do
                {
                    DBSave = RenderEntityCode.RandomEntityCode(10).ToLower();
                } while (companyList.FirstOrDefault(company => company.DBSave == DBSave) != null);
                // Tạo công ty mới
                var companyNew = new Company()
                {
                    CompanyName = regisInfor.CompanyName,
                    CompanyCode = RenderEntityCode.RandomEntityCode(10),
                    MST = regisInfor.MST,
                    Description = regisInfor.Description,
                    DBSave = DBSave,
                    Users = new List<UserPlatForm>() { userPlatform },
                    CreatedDate = DateTimeOffset.Now,
                    ModifiedDate = DateTimeOffset.Now,
                    CreatedBy = userPlatform.FullName,
                    ModifiedBy = userPlatform.FullName,
                };
                var numberRecord = await _companyRepo.InserEntity(companyNew);
                // Lấy thông tin company đã lưu
                var companySaved = await _companyRepo.GetCompanyByCompanyCode(companyNew.CompanyCode);
                // Insert mapping giữa người dùng và company
                await _companyRepo.InsertCompanyUserMapping(userPlatform, companySaved);
                // Khởi tạo domain mới 
                await _companyRepo.CreateNewCompany(companyNew.DBSave);
                // Thêm người dùng 
                await AddUserIntoCompany(companyNew.DBSave, userPlatform, true);
                // Đồng bộ người dùng vào db platform
                await _userPlatformRepo.UpdateIsAllowUserAccess(userPlatform.ID, companySaved.CompanyCode, true);
                await UnitOfWork.CommitAsync();
            } catch
            {
                await UnitOfWork.RollBackAsync();
                throw;
            } finally
            {
                await UnitOfWork.CloseAsync();
            }
            return true;
        }

        /// <summary>
        /// Nếu có tài khoản kiểm tra mật khẩu hợp lệ
        /// Nếu chưa có tài khoản thêm tài khoản mới
        /// </summary>
        /// <returns></returns>
        private async Task<UserPlatForm> ValidateUser(List<string> error, string fullName, string email, string password, string numberphone, Company company =  null)
        {
            // bản ghi chắc chắn có trong db
            var user = new UserPlatForm();
            // Kiểm tra tài khoản đã tồn tại chưa.
            var userExist = await _userPlatformRepo.GetUserByAccount(email);
            // Nếu tài khoản chưa tồn tại => tạo tài khoản mới
            if (userExist == null)
            {
                // Tạo ra người dùng mới
                var userInsert = new UserPlatForm()
                {
                    FullName = fullName,
                    Email = email,
                    Password = password,
                    PhoneNumber = numberphone,
                    CreatedBy = fullName,
                    CreatedDate = DateTimeOffset.Now,
                    ModifiedBy = fullName,
                    ModifiedDate = DateTimeOffset.Now,
                };
                await _userPlatformRepo.InserEntity(userInsert);
                user = await _userPlatformRepo.GetUserByAccountPassword(email, password);
                if (company != null)
                {
                    await _companyRepo.InsertCompanyUserMapping(user, company);
                }
            }
            else
            {
                // Kiểm tra mật khẩu đã chính xác chưa => nếu chính xác thêm mới công ty - nếu không: gửi lỗi về client.
                if (await _userPlatformRepo.GetUserByAccountPassword(email, password) == null)
                {
                    error.Add("RegisNewDomain_User");
                    throw new BusinessException(error);
                }
                user = userExist;
            }
            return user;
        }

        public async Task<ConfirmCode> ValidateConfirmToken(Guid confirmToken)
        {
            var inviteCodeExist = await _confirmRepo.GetConfirmCodeByCode(confirmToken);
            var error = new List<string>();
            // kiểm tra xem đã được sử dụng chưa
            if(inviteCodeExist.IsUsed)
            {
                error.Add("ConfirmCode_Used");
                throw new BusinessException(error);
            }
            var isExpert = (inviteCodeExist.CreateTime.ToUnixTimeSeconds() + (inviteCodeExist.Timeout * 60)) < DateTimeOffset.Now.ToUnixTimeSeconds();
            if (inviteCodeExist == null || isExpert)
            {
                error.Add("ConfirmCode_Expert");
                throw new BusinessException(error);
            }
            return inviteCodeExist;
        }

        public async Task<Company> GetCompanyByConfirmToken(Guid confirmToken)
        {
            var error = new List<string>();
            var confirmCode = await ValidateConfirmToken(confirmToken);
            if (confirmCode == null)
            {
                error.Add("RegisEmployee_Expert");
                throw new BusinessException(error);
            }
            return await _companyRepo.GetEntityByID(confirmCode.Company.ID);
        }

        /// <summary>
        /// Thêm người dùng vào công ty
        /// </summary>
        /// <returns></returns>
        private async Task AddUserIntoCompany(string dbsave, UserPlatForm userPlatform, bool isActive = false)
        {
            DbConnection cnn = null;
            DbTransaction tran = null;
            try
            {
                cnn = UnitOfWork.CreateNewConnection(UnitOfWork.BuildCnnString(dbsave));
                await cnn.OpenAsync();
                tran = await cnn.BeginTransactionAsync();
                // Nếu isActive là false => kiểm tra người dùng đã có trong domain chưa
                if(!isActive)
                {
                    var userExist = await _userRepo.GetUserByAccount(userPlatform.Email, cnn, tran);
                    if(userExist != null)
                    {
                        throw new BusinessException(new List<string>() { "User_Exist" });
                    }
                }
                var userList = await _userRepo.GetListEntities(cnn, tran, new PagingParameter());
                string userCode = "";
                do
                {
                    userCode = RenderEntityCode.RandomEntityCode(10);
                } while (userList.FirstOrDefault(user => user.UserCode == userCode) != null);
                var user = new User()
                {
                    UserCode = userCode,
                    FullName = userPlatform.FullName,
                    PhoneNumber = userPlatform.PhoneNumber,
                    Email = userPlatform.Email,
                    Password = userPlatform.Password,
                    IsActive = isActive,
                    UserPlatform = userPlatform,
                    CreatedDate = DateTimeOffset.Now,
                    ModifiedDate = DateTimeOffset.Now,
                    CreatedBy = userPlatform.FullName,
                    ModifiedBy = userPlatform.FullName,
                };
                await _userRepo.InserEntity(cnn, tran, user);
                tran.Commit();
            } catch
            {
                await tran?.RollbackAsync();
                throw;
            } finally
            {
                await cnn.CloseAsync();
            }
        }
    }
}

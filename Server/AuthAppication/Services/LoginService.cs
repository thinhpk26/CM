using Application.Service;
using AuthAppication.DTO;
using AuthAppication.DTO.CompanyDTO;
using AuthAppication.IServices;
using Repo.Entities;
using AuthRepo.IRepos;
using AuthRepo.Models;
using AuthRepo.Repos;
using AutoMapper;
using Business;
using Microsoft.IdentityModel.Tokens;
using Repo.Context;
using Repo.Enums;
using Repo.IRepo;
using Repo.Models;
using Repo.UnitOfWork;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace AuthAppication.Services
{
    public class LoginService : BaseService<UserPlatForm, UserPlatFormGetDTO, UserPlatFormInsertDTO, UserPlatFormUpdateDTO>, ILoginService
    {
        private readonly IUserPlatFormRepo _userPlatformRepo;
        private readonly ICompanyRepo _companyRepo;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;
        public LoginService(IUserPlatFormRepo userPlatformRepo, ICompanyRepo companyRepo, IConfiguration config, IMapper mapper, IUserRepo userRepo, ICMHttpContext context, IUnitOfWork unitOfWork) : base(userPlatformRepo, mapper, context, unitOfWork)
        {
            _userPlatformRepo = userPlatformRepo;
            _companyRepo = companyRepo;
            _config = config;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<string> Login(LoginInforModel loginInfor)
        {
            // Kiểm tra người dùng
            var error = new List<string>();
            if (string.IsNullOrWhiteSpace(loginInfor.Account))
            {
                error.Add("Login_Account_Empty");
            }
            if (string.IsNullOrWhiteSpace(loginInfor.Password))
            {
                error.Add("Login_Password_Empty");
            }
            if (error.Count > 0)
            {
                throw new BusinessException(error);
            }
            var userPlatform = await _userPlatformRepo.GetUserByAccountPassword(loginInfor.Account, loginInfor.Password);
            // Kiểm tra công ty
            if (userPlatform == null)
            {
                error.Add("Login_User");
                throw new BusinessException(error);
            }
            var company = await _companyRepo.GetCompanyByLoginInfor(loginInfor);
            if (company == null)
            {
                error.Add("Login_CompanyCode");
                throw new BusinessException(error);
            }
            // Lấy người dùng theo company
            var user = await _userRepo.GetUserByUserPlatformID(userPlatform.ID, company);
            
            // Loại bỏ các trường nhạy cảm
            var userSaveToken = _mapper.Map<UserContext>(user);
            var companySaveToken = _mapper.Map<CompanyContext>(company);
            string token = GenerateJsonToken(userSaveToken, companySaveToken);
            return token;
        }

        public string GenerateJsonToken(UserContext user, CompanyContext company)
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Issuer"];
            var key = Encoding.ASCII.GetBytes
            (_config["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("User", JsonSerializer.Serialize(user)),
                new Claim("Company", JsonSerializer.Serialize(company)),
                }),
                Expires = DateTime.UtcNow.AddMinutes(1440),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return jwtToken;
        }

        public async Task<UserPlatFormGetDTO> GetUserPlatformByAccountPassword(string account, string password)
        {
            var userPlatform = await _userPlatformRepo.GetUserByAccountPassword(account, password);

            var userPlatformGet = Mapper.Map<UserPlatFormGetDTO>(userPlatform);
            return userPlatformGet;
        }

        public async Task<string> ChangeCompany(int companyID, int userID)
        {
            var company = await _companyRepo.GetEntityByID(companyID);
            var userPlatform = await Repo.GetEntityByID(userID);
            // Lấy người dùng theo company
            var user = await _userRepo.GetUserByUserPlatformID(userPlatform.ID, company);

            // Loại bỏ các trường nhạy cảm
            var userSaveToken = _mapper.Map<UserContext>(user);
            var companySaveToken = _mapper.Map<CompanyContext>(company);
            string token = GenerateJsonToken(userSaveToken, companySaveToken);
            return token;
        }

        public async Task<bool> UpdateIsAllowUserAccess(long id, string companyCode, bool isAllowAccess)
        {
            var result = await _userPlatformRepo.UpdateIsAllowUserAccess(id, companyCode, isAllowAccess);
            return result;
        }
    }
}

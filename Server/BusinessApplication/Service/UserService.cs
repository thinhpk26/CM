using Application.IService;
using Application.Service;
using AutoMapper;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using Repo.Entities;
using Repo.Context;
using Repo.IRepo;
using Repo.UnitOfWork;
using BusinessRepo.IRepo;

namespace BusinessApplication.Service
{
    public class UserService : BaseService<User, UserGetDTO, UserInsertDTO, UserUpdateDTO>, IUserService
    {
        private readonly IUserRepo Repo;
        protected override string LayoutCode { get => "User"; }
        public UserService(IUserRepo repo, IMapper mapper, ICMHttpContext context, IUnitOfWork unitOfWork) : base(repo, mapper, context, unitOfWork)
        {
            Repo = repo;
        }
    }
}

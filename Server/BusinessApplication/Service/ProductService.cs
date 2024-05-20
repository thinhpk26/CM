using Application.Service;
using AutoMapper;
using BusinessApplication.DTO;
using BusinessApplication.IService;
using BusinessRepo.IRepo;
using BusinessRepo.Models;
using Repo.Context;
using Repo.Entities;
using Repo.IRepo;
using Repo.Models;
using Repo.UnitOfWork;

namespace BusinessApplication.Service
{
    public class ProductService : BaseService<Product, ProductGetDTO, ProductInsertDTO, ProductUpdateDTO>, IProductService
    {
        protected override string LayoutCode { get => "Product"; }

        protected readonly IProductRepo Repo;
        public ProductService(IProductRepo repo, IMapper mapper, ICMHttpContext context, IUnitOfWork unitOfWork) : base(repo, mapper, context, unitOfWork)
        {
            Repo = repo;
        }

        public async Task<List<ProductApplyPricebook>> ProductApplyPricebook(string? ID)
        {
            var result = await Repo.ProductApplyPricebook(ID);
            return result;
        }

    }
}

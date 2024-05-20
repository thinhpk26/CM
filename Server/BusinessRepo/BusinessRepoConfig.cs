using BusinessRepo.IRepo;
using BusinessRepo.Models;
using BusinessRepo.Repo;
using Microsoft.Extensions.DependencyInjection;
using Repo;
using Repo.Context;

namespace BusinessRepo
{
    public class BusinessRepoConfig
    {
        public static IServiceCollection AddService(IServiceCollection services)
        {
            RepoConfig.AddService(services);
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<ILayoutColumnRepo, LayoutColumnRepo>();
            services.AddScoped<ICommonRepo, CommonRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IContactRepo, ContactRepo>();
            services.AddScoped<ILeadRepo, LeadRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IPricebookRepo, PricebookRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            return services;
        }
    }
}

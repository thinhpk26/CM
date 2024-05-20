using AuthRepo.IRepos;
using AuthRepo.Repos;
using Repo;

namespace AuthRepo
{
    public class AuthRepoConfig
    {
        public static IServiceCollection AddService(IServiceCollection services)
        {
            RepoConfig.AddService(services);
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IConfirmCodeRepo, ConfirmCodeRepo>();
            services.AddScoped<ICompanyRepo, CompanyRepo>();
            services.AddScoped<IUserPlatFormRepo, UserPlatFormRepo>();
            return services;
        }
    }
}

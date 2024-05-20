using Repo.Context;
using Repo.UnitOfWork;

namespace Repo
{
    public class RepoConfig
    {
        public static IServiceCollection AddService(IServiceCollection service)
        {
            service.AddScoped<ICMHttpContext, CMHttpContext>();
            service.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            return service;
        }
    }
}

using Application;
using AuthAppication.IServices;
using AuthAppication.Services;

namespace AuthAppication
{
    public class AuthApplicationConfig
    {
        public static IServiceCollection AddService(IServiceCollection services)
        {
            ApplicationConfig.AddService(services);
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IConfirmCodeService, ConfirmCodeService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IRegisService, RegisService>();
            return services;
        }
    }
}

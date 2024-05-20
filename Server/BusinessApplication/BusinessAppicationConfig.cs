using Application;
using BusinessApplication.IService;
using BusinessApplication.Service;

namespace BusinessApplication
{
    public class BusinessAppicationConfig
    {
        public static IServiceCollection AddService(IServiceCollection services)
        {
            ApplicationConfig.AddService(services);
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ILayoutColumnService, LayoutColumnService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<ILeadService, LeadService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPricebookService, PricebookService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}

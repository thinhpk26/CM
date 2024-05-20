using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ApplicationConfig
    {
        public static IServiceCollection AddService(IServiceCollection service)
        {
            return service;
        }
    }
}

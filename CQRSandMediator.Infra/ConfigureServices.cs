using CQRSandMediator.Domain.Repository;
using CQRSandMediator.Infra.Data;
using CQRSandMediator.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSandMediator.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration ) 
        
        {
            services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("BlogBbContext") ??
                    throw new InvalidOperationException("connection string 'BlogBbContext not found '"))
            );

            services.AddTransient<IBlogRepository, BlogRepository>();
            return services;
        
        }
    }
}

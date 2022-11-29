using System;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//using ETicaretAPI.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace ETicaretAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistanceServices(this IServiceCollection services)
		{
			

			// Download the package about which Database will you use.
			// Example for Azure-SQL --> EntityCore.SqlServer
			// For Postgre-SQL --> EfCore.PostgreSQL or etc. 

			services.AddDbContext<ETicaretDbContext>(options  => options.UseNpgsql(Configuartion.ConnectionString), ServiceLifetime.Singleton);
			services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
					 
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
					 
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
        }
    };
} 


using ApplicationBanking.repository.Implements;
using ApplicationBanking.repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationBanking.Infrastructure.IoC
{
	public class IoCRegister
	{
		public static IServiceCollection GetConfiguration(IServiceCollection builder)
		{
			//Inject Services
			builder.AddScoped<IAccountMovementRepository, AccountMovementRepository>();
			builder.AddScoped<IAccountRepository, AccountRepository>();
			builder.AddScoped<IclientRepository, ClientRepository>();
			builder.AddScoped<IAccountMovementEntities, AccountMovementEntities>();
			
			return builder;
		}

		public static IServiceCollection AddDbContext(IServiceCollection services, string nameDb)
		{
			services.AddDbContext<bankingContext>(opt =>
			{
				opt.UseInMemoryDatabase(nameDb);
			});

			return services;
		}

		public static IServiceCollection AddMapper(IServiceCollection services)
		{
			var config = new MapperConfig();
			services.AddSingleton(config.getMappper());
			return services;
		}
	}
}

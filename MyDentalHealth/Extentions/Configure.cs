using Repository.Interfaces;
using Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.Interfaces;
using Services;

namespace MyDentalHealth.Extentions
{
	public static class Configure
	{
		public static void ConfigureRepository(this IServiceCollection serviceDescriptors)
		{
			serviceDescriptors.AddScoped<IRepositoryManager, RepositoryManager>();
			serviceDescriptors.AddScoped<IUserRepository, UserRepository>();
		}
		public static void ConfigureService(this IServiceCollection serviceDescriptors)
		{
			serviceDescriptors.AddScoped<IServiceManager, ServiceManager>();
			serviceDescriptors.AddScoped<IUserService, UserService>();

		}
		public static void ConfigureSqlConnection(this IServiceCollection serviceDescriptors, WebApplicationBuilder builder)
		{
			serviceDescriptors.AddDbContext<RepositoryContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("mssqlconnection"), b => b.MigrationsAssembly("My-Dental-Health"));
				options.EnableSensitiveDataLogging(true);
			});
		}
		public static void ConfigureEndPoints(this WebApplication webApplication)
		{
			webApplication.MapControllerRoute("default", "/{Controller=Home}/{action=Index}/{id?}");
			webApplication.MapControllers();
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;
using Services;
using Services.Interfaces;

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
		public static void ConfigureSession(this IServiceCollection serviceDescriptors)
		{
			serviceDescriptors.AddDistributedMemoryCache();

			serviceDescriptors.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromHours(1);
				options.Cookie.Name = ".mdh.Session";
				options.Cookie.HttpOnly = true;
				options.Cookie.IsEssential = true;
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
			});
		}
		public static void ConfigureSqlConnection(this IServiceCollection serviceDescriptors, WebApplicationBuilder builder)
		{
			serviceDescriptors.AddDbContext<RepositoryContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("mssqlconnection"), b => b.MigrationsAssembly("MyDentalHealth"));
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

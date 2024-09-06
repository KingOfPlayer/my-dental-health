using Microsoft.EntityFrameworkCore;
using MyDentalHealth.Extentions.Mapper;
using Repository;
using Repository.Interfaces;
using Service;
using Service.Interfaces;
using Service;
using Service.Interfaces;

namespace MyDentalHealth.Extentions
{
	public static class Configure
	{
		public static void ConfigureRepository(this IServiceCollection serviceDescriptors)
		{
			serviceDescriptors.AddScoped<IRepositoryManager, RepositoryManager>();
			serviceDescriptors.AddScoped<IUserRepository, UserRepository>();
			serviceDescriptors.AddScoped<ITargetRepository, TargetRepository>();
		}
		public static void ConfigureService(this IServiceCollection serviceDescriptors)
		{
			serviceDescriptors.AddScoped<IServiceManager, ServiceManager>();
			serviceDescriptors.AddScoped<IUserService, UserService>();
			serviceDescriptors.AddScoped<ITargetService, TargetService>();

			serviceDescriptors.AddAutoMapper(typeof(MappingProfile));

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
			},ServiceLifetime.Scoped);
		}
		public static void ConfigureEndPoints(this WebApplication webApplication)
		{
			webApplication.MapControllerRoute("default", "/{Controller=Home}/{action=Index}/{id?}");
			webApplication.MapControllers();
        }
    }
}

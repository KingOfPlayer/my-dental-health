using EntityRepository;
using EntityRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("mssqlconnection"), b => b.MigrationsAssembly("my-dental-health"));
	options.EnableSensitiveDataLogging(true);
});

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITargetRepository, TargetRepository>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute("default","/{Controller=Home}/{action=Index}/{id?}");
	endpoints.MapControllers();
});

app.Run();

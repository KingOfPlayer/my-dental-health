using MyDentalHealth.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.ConfigureSqlConnection(builder);

builder.Services.ConfigureRepository();
builder.Services.ConfigureService();
builder.Services.ConfigureSession();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles("/static");

app.UseSession();

app.ConfigureEndPoints();

app.Run();

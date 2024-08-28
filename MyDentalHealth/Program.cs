using Repository;
using Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Services;
using Services.Interfaces;
using MyDentalHealth.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.ConfigureSqlConnection(builder);

builder.Services.ConfigureRepository();
builder.Services.ConfigureService();

var app = builder.Build();

app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles("/static");

app.ConfigureEndPoints();

app.Run();

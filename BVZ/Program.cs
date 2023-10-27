using BVZ.BVZ.Application.Interfaces;
using BVZ.BVZ.Application.Services;
using BVZ.BVZ.Infrastructure.Data;
using BVZ.BVZ.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using static BVZ.BVZ.Domain.Models.Zoo.Animals.Animal;

/*
Deltagare i projektet:
Tobias Ott
Andreas Gustavsson
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ZooDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                   builder => builder.MigrationsAssembly(typeof(ZooDbContext).Assembly.FullName)));


//Ska vi bry oss om en separat config för DI repos?
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddTransient<IGuideRepository, GuideRepository>();
builder.Services.AddTransient<ITourRepository, TourRepository>();
builder.Services.AddTransient<IZooRepository, ZooRepository>();
builder.Services.AddTransient<IVisitorRepository, VisitorRepository>();
builder.Services.AddTransient<ITransaction, BaseRepository>();
builder.Services.AddTransient<IAnimalCompetencesRepository, AnimalCompetencesRepository>();

// Add application-services
builder.Services.AddTransient<TourService>();
builder.Services.AddTransient<AnimalServices>();
builder.Services.AddTransient<GuideServices>();
builder.Services.AddTransient<VisitorServices>();
builder.Services.AddTransient<AnimalFactory>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

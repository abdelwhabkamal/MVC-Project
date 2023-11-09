using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.ComponentModel;
using TestCoreApp.Data;
using TestCoreApp.Repository;
using TestCoreApp.Repository.Base;

var builder = WebApplication.CreateBuilder(args);
// builder.Services: This typically refers to an instance of IServiceCollection used for configuring services and dependencies in an ASP.NET Core application. It's part of the DI container configuration.
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("MyConnection")
    ));
// "transient" service means that a new instance of the service will be created every time it is requested

//builder.Services.AddTransient(typeof(IRepository<>), typeof(MainRepository<>));

//registers a transient dependency in a .NET application using the dependency injection(DI) container
builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "area",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

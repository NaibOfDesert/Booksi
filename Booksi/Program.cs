using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design; 
using Booksi.DataAccess.Data;
using Booksi.DataAccess.Repository.IRepository;
using Booksi.DataAccess.Repository.Repository;

/* Program basic run informations:
 * To use Docekr Compose use connection string with "DefaultConnection".
 * To use Dotnet Run use connection string with "LocalhostConnection".
 * To create database migration use dotnet ef --startup-project ../Booksi/ migrations add Initial from terminal in Booksi.DataAccess.
 * To update database use dotnet ef database update from Booksi with connection string "LocalhostConnection".
**/

/* Program possible errors informations:
 *  After an unsuccessful attempt to close the database server, you may get an error, which will start counting the id for new items by 1000.
**/

var builder = WebApplication.CreateBuilder(args);

// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection String 'DefaultConnection' not found.");
var connectionString = builder.Configuration.GetConnectionString("LocalhostConnection") ?? throw new InvalidOperationException("Connection String 'LocalhostConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


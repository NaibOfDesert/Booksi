using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design; 
using Booksi.DataAccess.Data;
using Booksi.DataAccess.Repository.Repository;
using Booksi.DataAccess.Repository.IRepository;
using Booski.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Booksi.Utility;
using Microsoft.Playwright;


/* Program basic run informations:
 * To use Docekr Compose use connection string with "DefaultConnection".
 * To use Dotnet Run use connection string with "LocalhostConnection".
 * To create database migration use dotnet ef --startup-project ../Booksi/ migrations add Initial from terminal in ../Booksi.DataAccess/.
 * To update database use dotnet ef database update from ../Booksi/ with connection string "LocalhostConnection".
**/

/* Program possible errors informations:
 *  After an unsuccessful attempt to close the database server, you may get an error, which will start counting the id for new items by 1000.
**/

var builder = WebApplication.CreateBuilder(args);

string connectionString = string.Empty; 
var connectionKey = args.FirstOrDefault(a => a.StartsWith("--connection="))?.Split('=')[1] ?? "DefaultConnection";

switch (connectionKey){
    default:
    case null:
    case "dev":
        // connectionString for: dotnet build / dotnet run -? in  -> IN BOOKSI.BOOKSI folder
        connectionString = builder.Configuration.GetConnectionString("LocalhostConnection") ?? throw new InvalidOperationException("Connection String 'LocalhostConnection' not found.");
        break;  
    case "prod":
        // connectionString for: docker compose up --build
        connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection String 'DefaultConnection' not found.");
        break;

}

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

// builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddRazorPages();

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

app.UseAuthentication();
app.UseAuthorization();


app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}"
    );


app.Run();




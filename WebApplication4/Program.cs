using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication4.Contexts;
using WebApplication4.Models.Concretes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer("server=DESKTOP-4RCDPUA\\SQLEXPRESS;database=BezdimDayy;Integrated Security=true;Encrypt=false");
});

builder.Services.AddIdentity<AppUser,IdentityRole>(opt =>
{
    opt.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
});


var app = builder.Build();



app.UseStaticFiles();


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller}/{action}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}");


app.UseAuthentication();
app.UseAuthorization();

app.Run();

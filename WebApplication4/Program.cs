using Microsoft.EntityFrameworkCore;
using WebApplication4.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer("server=.;database=BezdimDay;Integrated Security=true;Encrypt=false");
});

var app = builder.Build();



app.UseStaticFiles();


app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller}/{action}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action}");




app.Run();

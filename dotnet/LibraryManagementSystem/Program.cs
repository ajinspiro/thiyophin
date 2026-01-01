using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Database
builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(
        "Server=localhost;Database=Library_Database;User Id=sa;Password=31eq#EQDA;Encrypt=False;"
    ));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();   // serves HTML from wwwroot
app.UseRouting();


// ✅ ONE conventional route (THIS is routing)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Members}/{action=Index}/{id?}");

app.Run();

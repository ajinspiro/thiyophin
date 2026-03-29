using Microsoft.Extensions.Options;
using NuPhonesApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddWebOptimizer(pipeline =>
{
    pipeline.AddCssBundle("/css/site.bundle.css",
        "css/common/base.css",
        "css/common/header.css",
        "css/accounts/login.css",
        "css/accounts/signup.css",
        "css/home/landing.css");

    pipeline.AddJavaScriptBundle("/js/site.bundle.js",
        "js/site.js",
        "js/home.js");
});
builder.Services.AddIdentityCore<IdentityUser>().
    AddRoles<IdentityRole>().
    AddRoleManager<RoleManager<IdentityRole>>().
    AddSignInManager<SignInManager<IdentityUser>>().
    AddUserManager<UserManager<IdentityUser>>().
    AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Static files must come early
app.UseWebOptimizer();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

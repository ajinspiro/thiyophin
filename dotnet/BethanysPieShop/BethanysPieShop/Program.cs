using System.Security;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;



// var builder = new DbContextOptionsBuilder<BethanysPieShopDbContext>();
// builder = builder.UseSqlServer("asdfasdf");
// var options = builder.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();

builder.Services.AddControllersWithViews(); // making our console app know to use MVC
builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});
var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapDefaultControllerRoute();
DbInitializer.Seed(app);
app.Run();



// XUV700<PetrolEngine> petrolCar = new();

// public class XUV700<TEngine> where TEngine : IPetrolEngine, new()
// {
//     TEngine Engine = new TEngine();

//     void StartEngine()
//     {
//         Console.WriteLine(Engine.Type);
//     }

// }

// public interface IPetrolEngine
// {
//     string Type { get; set; }
// }

// public class PetrolEngine : IPetrolEngine
// {
//     public string Type { get; set; } = "Petrol";
// }

// public abstract class Person
// {
//     public Person()
//     {

//     }

//     public abstract void Eat();
//     public void Walk()
//     {

//     }
// }
// public interface ICar
// {
//     public void StartEngine();
// }
// public class Car : ICar
// {
//     public void StartEngine()
//     {
//         System.Console.WriteLine();
//     }
// }
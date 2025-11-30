using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApp.Data;
using SampleApp.Data.Models;
using SampleApp.Models;

namespace SampleApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SampleDbContext _sampleDb;

    public HomeController(ILogger<HomeController> logger, SampleDbContext sampleDb)
    {
        _sampleDb = sampleDb;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> FindData()
    {
        var names = await _sampleDb.SampleTables.ToListAsync();
        return Ok(names);
    }
    public async Task<IActionResult> AddDummyData()
    {
        SampleTable myTableObj = new SampleTable();
        myTableObj.Name = "Arun Kumar";
        await _sampleDb.AddAsync(myTableObj);
        await _sampleDb.SaveChangesAsync();
        return Ok("Created !");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

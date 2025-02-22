using System.Diagnostics;
using CrudMvc.Context;
using Microsoft.AspNetCore.Mvc;
using CrudMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMvc.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }
    

    public async Task<IActionResult> Index()
    {
        return View(await _context.contatos.ToListAsync());
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
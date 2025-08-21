using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PerpustakaanMVC.Models;
using PerpustakaanMVC.Data;

namespace PerpustakaanMVC.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.TotalBuku = _context.Buku.Count();
        ViewBag.TotalAnggota = _context.Anggota.Count();
        ViewBag.TotalPeminjaman = _context.Peminjaman.Count();
        return View();
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

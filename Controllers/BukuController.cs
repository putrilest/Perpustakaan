using Microsoft.AspNetCore.Mvc;
using PerpustakaanMVC.Data;
using PerpustakaanMVC.Models;

namespace PerpustakaanMVC.Controllers
{
    public class BukuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BukuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Buku
        public IActionResult Index()
        {
            var daftarBuku = _context.Buku.ToList();
            return View(daftarBuku);
        }

        // GET: Buku/Detais/3
        public IActionResult Details(int id)
        {
            var buku = _context.Buku.FirstOrDefault(b => b.Id == id);
            if (buku == null) return NotFound();
            return View(buku);
        }

        // GET: Buku/create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Buku/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Buku buku)
        {
            if (ModelState.IsValid)
            {
                _context.Buku.Add(buku);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(buku);
        }

        // GET: Buku/Edit/3
        public IActionResult Edit(int id)
        {
            var buku = _context.Buku.Find(id);
            if (buku == null)
            {
                return NotFound();
            }
            return View(buku);
        }

        // POST: Buku/Edit/3
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Buku buku)
        {
            if (id != buku.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Buku.Update(buku);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(buku);
        }

        // GET: Buku/Delete/5
        public IActionResult Delete(int id)
        {
            var buku = _context.Buku.Find(id);
            if (buku == null)
            {
                return NotFound();
            }
            return View(buku);
        }

        //POST: Buku/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var buku = _context.Buku.Find(id);
            if(buku != null)
            {
                _context.Buku.Remove(buku);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
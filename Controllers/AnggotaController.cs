using Microsoft.AspNetCore.Mvc;
using PerpustakaanMVC.Data;
using PerpustakaanMVC.Models;

namespace PerpustakaanMVC.Controllers
{
    public class AnggotaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnggotaController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Anggota
        public IActionResult Index()
        {
            var anggota = _context.Anggota.ToList();
            return View(anggota);
        }

        //GET: Anggota/Details/5
        public IActionResult Details(int id)
        {
            var anggota = _context.Anggota.FirstOrDefault(a => a.Id ==  id);
            if (anggota == null)
            {
                return NotFound();
            }
            return View(anggota);
        }

        //GET: Anggota/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Anggota/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Anggota anggota)
        {
            if (ModelState.IsValid)
            {
                _context.Anggota.Add(anggota);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(anggota);
        }

        //GET: Anggota/Edit/5
        public IActionResult Edit(int id)
        {
            var anggota = _context.Anggota.FirstOrDefault(a => a.Id == id);
            if (anggota == null)
            {
                return NotFound();
            }
            return View(anggota);
        }

        //POST: Anggota/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Anggota anggota)
        {
            if (id != anggota.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                _context.Update(anggota);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(anggota);
        }

        //GET: Anggota/Delete/5
        public IActionResult Delete(int id)
        {
            var anggota = _context.Anggota.FirstOrDefault(a => a.Id == id);
            if (anggota == null)
            {
                return NotFound();
            }
            return View(anggota);
        }

        //POST: Anggota/Delete/6
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var anggota = _context.Anggota.FirstOrDefault(a => a.Id == id);
            if (anggota != null)
            {
                _context.Anggota.Remove(anggota);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
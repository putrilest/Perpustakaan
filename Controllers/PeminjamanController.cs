using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PerpustakaanMVC.Models;
using PerpustakaanMVC.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace PerpustakaanMVC.Controllers
{
    public class PeminjamanController : Controller
    {
        public readonly ApplicationDbContext _context;

        public PeminjamanController (ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peminjaman
        public async Task<IActionResult> Index(string searchString)
        {
            var peminjaman = _context.Peminjaman
                                     .Include(p => p.Buku)
                                     .Include(p => p.Anggota)
                                     .AsQueryable();
            
            if(!string.IsNullOrEmpty(searchString))
            {
                peminjaman = peminjaman.Where(p =>
                    p.Buku.Judul.Contains(searchString) ||
                    p.Anggota.Nama.Contains(searchString) ||
                    p.TanggalPinjam.ToString().Contains(searchString));
            }
            return View(await peminjaman.ToListAsync());
        }


        //GET: Peminjaman/Detail/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id ==  null) return NotFound();

            var peminjaman = await _context.Peminjaman
                .Include(p => p.Buku)
                .Include(p => p.Anggota)
                .FirstOrDefaultAsync(m => m.Id == id);

            if(peminjaman == null) return NotFound();

            return View(peminjaman);
        }

        // GET: Peminjaman/Create
        public IActionResult Create()
        {
            ViewData["BukuId"] = new SelectList(_context.Buku, "Id", "Judul");
            ViewData["AnggotaId"] = new SelectList(_context.Anggota, "Id", "Nama");
            return View();
        }

        // POST: Peminjaman/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peminjaman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // penting! isi ulang dropdown kalau gagal
            ViewData["BukuId"] = new SelectList(_context.Buku, "Id", "Judul", peminjaman.BukuId);
            ViewData["AnggotaId"] = new SelectList(_context.Anggota, "Id", "Nama", peminjaman.AnggotaId);

            return View(peminjaman);
        }

        // GET: Peminjaman/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null) return NotFound();

            ViewData["BukuId"] = new SelectList(_context.Buku, "Id", "Judul", peminjaman.BukuId);
            ViewData["AnggotaId"] = new SelectList(_context.Anggota, "Id", "Nama", peminjaman.AnggotaId);

            return View(peminjaman);
        }

        // POST: Peminjaman/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Peminjaman peminjaman)
        {
            if (id != peminjaman.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peminjaman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Peminjaman.Any(e => e.Id == peminjaman.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(peminjaman);
        }

        // GET: Peminjaman/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var peminjaman = await _context.Peminjaman
                .Include(p => p.Buku)
                .Include(p => p.Anggota)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (peminjaman == null) return NotFound();

            return View(peminjaman);
        }

        // POST: Peminjaman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            _context.Peminjaman.Remove(peminjaman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }    
}
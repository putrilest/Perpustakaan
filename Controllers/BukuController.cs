using Microsoft.AspNetCore.Mvc;
using PerpustakaanMVC.Data;
using PerpustakaanMVC.Models;

namespace PerpustakaanMVC.Controllers
{
    public class BukuController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public BukuController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
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
        public IActionResult Create(Buku buku, IFormFile fotoSampul)
        {
            Console.WriteLine("=== Create Buku dipanggil ===");
            Console.WriteLine($"Judul: {buku.Judul}");
            Console.WriteLine($"Foto ada? {(fotoSampul != null ? "YA" : "TIDAK")}");

            if (ModelState.IsValid)
            {
                if (fotoSampul != null && fotoSampul.Length > 0)
                {
                    try
                    {
                        var uploadFolder = Path.Combine(_environment.WebRootPath, "images");
                        if (!Directory.Exists(uploadFolder))
                        {
                            Directory.CreateDirectory(uploadFolder);
                        }

                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(fotoSampul.FileName);
                        var filePath = Path.Combine(uploadFolder, fileName);

                        Console.WriteLine($"Simpan ke: {filePath}");

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            fotoSampul.CopyTo(stream);
                        }

                        buku.FotoSampul = "/images/" + fileName;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("GAGAL SIMPAN FILE: " + ex.Message);
                    }
                }

                _context.Buku.Add(buku);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                Console.WriteLine("ModelState TIDAK VALID");
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
        public IActionResult Edit(int id, Buku buku, IFormFile fotoSampul)
        {
            if (id != buku.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Upload foto baru jika ada
                if (fotoSampul != null && fotoSampul.Length > 0)
                {
                    var uploadFolder = Path.Combine(_environment.WebRootPath, "images");
                    if (!Directory.Exists(uploadFolder))
                    {
                        Directory.CreateDirectory(uploadFolder);
                    }

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(fotoSampul.FileName);
                    var filePath = Path.Combine(uploadFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        fotoSampul.CopyTo(stream);
                    }

                    buku.FotoSampul = "/images/" + fileName;
                }

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
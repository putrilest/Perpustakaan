using Microsoft.EntityFrameworkCore;
using PerpustakaanMVC.Models;

namespace PerpustakaanMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) {}

        public DbSet<Buku> Buku {get; set;}
        public DbSet<Anggota> Anggota {get; set;}
        public DbSet<Peminjaman> Peminjaman {get; set;}
    }
}
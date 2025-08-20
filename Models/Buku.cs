using System.ComponentModel.DataAnnotations;

namespace PerpustakaanMVC.Models
{
    public class Buku
    {
        public int Id {get; set;}

        [Required]
        public string Judul {get; set;}

        public string Penulis {get; set;}

        public string Penerbit {get; set;}

        public string TahunTerbit {get; set;}

        public int JumlahHalaman {get; set;}

        public bool StatusDipinjam {get; set;} = false;
    }
}
using System.ComponentModel.DataAnnotations;

namespace PerpustakaanMVC.Models
{
    public class Anggota
    {
        public int Id {get; set;}

        [Required]
        public string Nama {get; set;}

        public string Alamat {get; set;}

        public string Telepon {get; set;}
    }
}
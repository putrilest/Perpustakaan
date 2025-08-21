using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace PerpustakaanMVC.Models
{
    public class Peminjaman
    {
        public int Id { get; set;}

        public int BukuId {get; set;}
        public int AnggotaId {get; set;}

        [ForeignKey("BukuId")]
        [ValidateNever]
        public Buku Buku {get; set;}

        [ForeignKey("AnggotaId")]
        [ValidateNever]
        public Anggota Anggota {get; set;}

        public DateTime TanggalPinjam {get; set;} = DateTime.Now;
        public DateTime? TanggalKembali {get;set;}
    }
}
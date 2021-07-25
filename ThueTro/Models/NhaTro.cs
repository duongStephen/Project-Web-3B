using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThueTro.Models
{
    public class NhaTro
    {
        [Key]
        public int IDNha { get; set; }
        [StringLength(500)]
        
        public string Tenduong { get; set; }
        public string DienTich { get; set; }
        [StringLength(50)]
        public string TenChuNha { get; set; }
        public string SDT { get; set; }
        [StringLength(500)]
        public string CTNha { get; set; }
        [StringLength(500)]
        public string GioiThieu { get; set; }
        [StringLength(50)]
        public string Gia { get; set; }
        public string image { get; set; }
        public string image2 { get; set; }
        public string image3 { get; set; }
        public int ratting { get; set; }
        public DiaDiem diaDiem { get; set; }
        public string IDQuann { get; set; }
        public DateTime DateTime { get; set; }

    }
}
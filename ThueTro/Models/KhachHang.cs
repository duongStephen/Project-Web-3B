using System.ComponentModel.DataAnnotations;

namespace ThueTro.Models
{
    public class KhachHang
    {
        [Key]
        public int IDKH { get; set; }
        public string SDT { get; set; }
        [StringLength(50)]
        public string HoTen { get; set; }
        [StringLength(500)]
        public string DiaChi { get; set; }
    }
}
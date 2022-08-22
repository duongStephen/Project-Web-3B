using System.ComponentModel.DataAnnotations;

namespace ThueTro.Models
{
    public class DiaDiem
    {
        [Key]
        public byte IDQuan { get; set; }

        [StringLength(50)]
        public string TenQuan { get; set; }
    }
}
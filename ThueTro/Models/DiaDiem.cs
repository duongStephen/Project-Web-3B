using System.ComponentModel.DataAnnotations;

namespace ThueTro.Models
{
    public class DiaDiem
    {
        [Key]
        [Display(Name = "ID quận")]
        public byte IDQuan { get; set; }

        [Display(Name = "Tên quận")]
        [StringLength(50)]
        public string TenQuan { get; set; }
    }
}
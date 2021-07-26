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
        [Display(Name = "STT")]
        public int IDNha { get; set; }

        [StringLength(500), Required(ErrorMessage = "Chưa nhập tên đường"), Display(Name = "Tên đường")]
        public string Tenduong { get; set; }

        [Display(Name = "Diện tích"), Required(ErrorMessage = "Chưa nhập diện tích")]
        public string DienTich { get; set; }

        [StringLength(50), Display(Name = "Tên chủ nhà"), Required(ErrorMessage = "Chưa nhập tên chủ nhà")]
        public string TenChuNha { get; set; }

        [Display(Name = "SDT liên hệ"), Required(ErrorMessage = "Chưa nhập SDT liên hệ"), DataType(DataType.PhoneNumber), Phone]
        public string SDT { get; set; }

        [StringLength(500), Display(Name = "Chi tiết nhà"), Required(ErrorMessage = "Chưa nhập chi tiết nhà")]
        public string CTNha { get; set; }

        [StringLength(500), Display(Name = "Giới thiệu"), Required(ErrorMessage = "Chưa nhập giới thiệu")]
        public string GioiThieu { get; set; }

        [StringLength(50), Display(Name = "Giá"), Required(ErrorMessage = "Chưa nhập giá")]
        public string Gia { get; set; }

        [Display(Name = "Ảnh")]
        public string image { get; set; }

        [Display(Name = "Ảnh 2")]
        public string image2 { get; set; }

        [Display(Name = "Ảnh 3")]
        public string image3 { get; set; }

        [Display(Name ="Ratting"), Required]
        public int ratting { get; set; }

        [Display(Name = "Quận"), Required]
        public byte DiaDiemIdQuan { get; set; }

        public DiaDiem DiaDiem { get; set; }

        [Display(Name = "Thời gian"), Required]
        public DateTime DateTime { get; set; }

    }
}
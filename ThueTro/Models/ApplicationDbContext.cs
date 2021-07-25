using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ThueTro.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<DiaDiem> DiaDiems { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhaTro> NhaTros { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
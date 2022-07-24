using Microsoft.EntityFrameworkCore;

namespace AspNetMVCEgitimi.NETCore.Models
{
    public class DatabaseContext : DbContext
    {
        // .net core da entity framework için core versiyonu mevcut
        // EF Core için nuget dan yüklenecek paketler
        // EntityFrameworkCore, EntityFrameworkCore.SqlServer, EntityFrameworkCore.Tools
        // Paketleri yükledikten sonra Program.cs ye DatabaseContext i eklemeliyiz!

        public DbSet<Product> Products { get; set; } // Veritabanı tablolarımızı temsil edecek classlarımızı dbset olarak tanımlıyoruz
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

using System.Data.Entity; // EF kütüphanesini dahil ediyoruz

namespace AspNetMVCEgitimi.NETFramework.Models
{
    public class DatabaseContext : DbContext // DatabaseContext bizim db setlerimizi tutacak classımız. DbContext ise Entity frameworkün veritabanı işlemleri için bize sunduğu class
    {
        public DbSet<Product> Products { get; set; } // Veritabanı tablolarımızı temsil edecek classlarımızı dbset olarak tanımlıyoruz
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
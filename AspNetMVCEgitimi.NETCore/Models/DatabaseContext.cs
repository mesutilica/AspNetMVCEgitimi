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
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; Database=AspNetCoreMvcEgitim; integrated security=true; MultipleActiveResultSets=True"); // Uygulamamıza veritabanı bilgilerimizi tanıttık
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Veritabanı oluşturulduktan sonra kullanıcılar tablosunda kayıt yoksa varsayılan admin kullanıcısı oluşturmak için aşağıdaki kodu yazdık
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    IsActive = true,
                    IsAdmin = true,
                    Password = "123",
                    Username = "Admin"
                }
                );
            base.OnModelCreating(modelBuilder);
            // Bu aşamadan sonra migrationu oluşturmamız gerekiyor
            // bunun için Package manager console u açıp migrationun kurulacağı projeyi seçip add-migration InitialCreate komutunu yazıp enter a basıyoruz. Migration oluştuktan sonra update-database komutu ile veritabanımızı oluşturabiliriz.
        }
    }
}

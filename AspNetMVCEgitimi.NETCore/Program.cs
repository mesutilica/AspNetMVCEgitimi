using AspNetMVCEgitimi.NETCore.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(1); // session a 1 dk l�k ya�am s�resi tan�mlad�k
}); // Projede session kullanabilmek i�in bu kodu eklemeliyiz!
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer()); // DatabaseContext i projeye ekledik ve sql server kullanaca��m�z� belirttik

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession(); // uygulaman�n session � kullanmas�n� sa�lad�k

app.UseCookiePolicy(); // uygulamada cookie kullanabilmek i�in

app.UseRouting();

app.UseAuthorization();

// A�a��daki kodu admin areas�n� kullanabilmek i�in ekledik!
app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using E_Kitabxana.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Kitabxana.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cart> Carts { get; set; }
      
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Category>().HasData(
              new Category { Id = 1, Name = "Tarix" },
              new Category { Id = 2, Name = "Roman" },
              new Category { Id = 3, Name = "Psixologiya" },
              new Category { Id = 4, Name = "Fəlsəfə" },
              new Category { Id = 5, Name = "Elm" }
          );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Elçibəy", Author = " Mehmet Necati Dəmircan", Price = 11.82m, ImageUrl = "https://static.insales-cdn.com/images/products/1/800/833495840/ELCIBEY_qapaq__1_.jpg", About = "Sənədli-bədii tarixi roman Azərbaycan nəşri üçün yenidən işlənib." },
                new Book { Id = 2, Title = "Hamilə qız", Author = "Aləm Kəngərli", Price = 4.25m, ImageUrl = "https://static.insales-cdn.com/r/3WeQLHOLHXk/rs:fit:570:570:1/q:80/plain/images/products/1/2841/2848353049/2025-11-24-11-46-251763970385.jpg@webp", About = "\"Hamilə qız\" povestində sevgi və mənəviyyat xətti işlənib." },
                new Book { Id = 3, Title = "13-cü Kottecin Sirri", Author = "Nəzakət Cavadova", Price = 13.60m, ImageUrl = "https://static.insales-cdn.com/images/products/1/7401/2848292073/2026-03-09-16-16-221773058582.png", About = "Bu roman sevginin xilas yox, hökmə çevrildiyi bir dünyada vicdan, sədaqət və günah arasında parçalanan insanların hekayəsidir." },
                new Book { Id = 4, Title = "Əyləncəli fəlsəfə", Author = "Ömər Sevinçgül", Price = 8.45m, ImageUrl = "https://static.insales-cdn.com/images/products/1/673/2848072353/ANI_YASHA_qapaq.jpg", About = "Fəlsəfə tarixinin məşhur filosofları otağımda peyda oldular." },
                new Book { Id = 5, Title = "İkigai", Author = "Bettina Lemke", Price = 8.49m, ImageUrl = "https://static.insales-cdn.com/images/products/1/6425/2926074137/IKIGAI_qapaq.jpg", About = "Öz həyatını mənalandırmağı və onu gündəlik həyatda tapmağı bacaran insan xoşbəxtdir." },
                new Book { Id = 6, Title = "Pulun Psixologiyası", Author = "Morqan Haruzel", Price = 10.19m, ImageUrl = "https://static.insales-cdn.com/images/products/1/3457/2926046593/PULUN_PSIXOLOGIYASI_qapaq.jpg", About = "Pul məsələsini daha yaxşı öyrədən hekayələr toplusudur." },
                new Book { Id = 7, Title = "Mafiya şahid saxlamır", Author = "Sabir Şahtaxtı", Price = 10.12m, ImageUrl = "https://static.insales-cdn.com/images/products/1/4465/2908098929/2026-03-09-15-15-201773054920.png", About = "Cəmiyyətin dərin təzadlarını əks etdirən detektiv janrda yazılan bestsellər." },
                new Book { Id = 8, Title = "Həmin o an", Author = "Qurban Səid", Price = 10.63m, ImageUrl = "https://static.insales-cdn.com/images/products/1/5401/2851656985/WhatsApp_Image_2026-03-17_at_10.36.11.jpeg", About = "Bəzən həyat səssiz görünür. Sanki hər şey axır, amma heç nə dəyişmir." },
                new Book { Id = 9, Title = "Всего шесть чисел", Author = "Мартин Рис", Price = 11.34m, ImageUrl = "https://static.insales-cdn.com/images/products/1/2585/2855471641/7135681377-large.webp", About = "Ключевые понятия космологии описаны доступным языком." },
                new Book { Id = 10, Title = "Двенадцатая планета", Author = "Захария Ситчин", Price = 11.34m, ImageUrl = "https://static.insales-cdn.com/images/products/1/1977/2855471033/7328593592.webp", About = "За многие годы исследований были обнаружены удивительные свидетельства о происхождении Земли." },
                new Book { Id = 11, Title = "Üç yoldaş", Author = "Erix Mariya Remark", Price = 11.04m, ImageUrl = "https://static.insales-cdn.com/images/products/1/265/2904301833/UC_YOLDASH_qapaq.jpg", About = "Hadisələr Birinci Dünya müharibəsindən sonrakı Almaniyada cərəyan edir." }
            );
            base.OnModelCreating(modelBuilder);
          
        }
    }
}
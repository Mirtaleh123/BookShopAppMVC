using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Kitabxana.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "About", "Author", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Sənədli-bədii tarixi roman Azərbaycan nəşri üçün yenidən işlənib.", " Mehmet Necati Dəmircan", "https://static.insales-cdn.com/images/products/1/800/833495840/ELCIBEY_qapaq__1_.jpg", 11.82m, "Elçibəy" },
                    { 2, "\"Hamilə qız\" povestində sevgi və mənəviyyat xətti işlənib.", "Aləm Kəngərli", "https://static.insales-cdn.com/r/3WeQLHOLHXk/rs:fit:570:570:1/q:80/plain/images/products/1/2841/2848353049/2025-11-24-11-46-251763970385.jpg@webp", 4.25m, "Hamilə qız" },
                    { 3, "Bu roman sevginin xilas yox, hökmə çevrildiyi bir dünyada vicdan, sədaqət və günah arasında parçalanan insanların hekayəsidir.", "Nəzakət Cavadova", "https://static.insales-cdn.com/images/products/1/7401/2848292073/2026-03-09-16-16-221773058582.png", 13.60m, "13-cü Kottecin Sirri" },
                    { 4, "Fəlsəfə tarixinin məşhur filosofları otağımda peyda oldular.", "Ömər Sevinçgül", "https://static.insales-cdn.com/images/products/1/673/2848072353/ANI_YASHA_qapaq.jpg", 8.45m, "Əyləncəli fəlsəfə" },
                    { 5, "Öz həyatını mənalandırmağı və onu gündəlik həyatda tapmağı bacaran insan xoşbəxtdir.", "Bettina Lemke", "https://static.insales-cdn.com/images/products/1/6425/2926074137/IKIGAI_qapaq.jpg", 8.49m, "İkigai" },
                    { 6, "Pul məsələsini daha yaxşı öyrədən hekayələr toplusudur.", "Morqan Haruzel", "https://static.insales-cdn.com/images/products/1/3457/2926046593/PULUN_PSIXOLOGIYASI_qapaq.jpg", 10.19m, "Pulun Psixologiyası" },
                    { 7, "Cəmiyyətin dərin təzadlarını əks etdirən detektiv janrda yazılan bestsellər.", "Sabir Şahtaxtı", "https://static.insales-cdn.com/images/products/1/4465/2908098929/2026-03-09-15-15-201773054920.png", 10.12m, "Mafiya şahid saxlamır" },
                    { 8, "Bəzən həyat səssiz görünür. Sanki hər şey axır, amma heç nə dəyişmir.", "Qurban Səid", "https://static.insales-cdn.com/images/products/1/5401/2851656985/WhatsApp_Image_2026-03-17_at_10.36.11.jpeg", 10.63m, "Həmin o an" },
                    { 9, "Ключевые понятия космологии описаны доступным языком.", "Мартин Рис", "https://static.insales-cdn.com/images/products/1/2585/2855471641/7135681377-large.webp", 11.34m, "Всего шесть чисел" },
                    { 10, "За многие годы исследований были обнаружены удивительные свидетельства о происхождении Земли.", "Захария Ситчин", "https://static.insales-cdn.com/images/products/1/1977/2855471033/7328593592.webp", 11.34m, "Двенадцатая планета" },
                    { 11, "Hadisələr Birinci Dünya müharibəsindən sonrakı Almaniyada cərəyan edir.", "Erix Mariya Remark", "https://static.insales-cdn.com/images/products/1/265/2904301833/UC_YOLDASH_qapaq.jpg", 11.04m, "Üç yoldaş" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}

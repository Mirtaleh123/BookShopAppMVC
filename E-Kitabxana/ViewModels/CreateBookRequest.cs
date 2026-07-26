using System.ComponentModel.DataAnnotations;

namespace E_Kitabxana.ViewModels
{
    public class CreateBookViewModel
    {
        [Required(ErrorMessage = "Kitabın adı boş ola bilməz")]
        [StringLength(200)]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Müəllif adı lazımdır")]
        [StringLength(100)]
        public string Author { get; set; } = "";

        [Range(1, 1000, ErrorMessage = "Qiymət 1-1000 arasında olmalıdır")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Şəkil linki lazımdır")]
        public string ImageUrl { get; set; } = "";

        [Required(ErrorMessage = "Kitab haqqında məlumat lazımdır")]
        [StringLength(1000)]
        public string About { get; set; } = "";
    }
}
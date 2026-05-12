using System.ComponentModel.DataAnnotations;

namespace Book_Shop.ViewModels
{
    public class CreateBookRequest
    {
        [Required(ErrorMessage = "Kitabın adı boş ola bilməz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Müəllif adı lazımdır")]
        public string Author { get; set; }

        [Range(1, 1000, ErrorMessage = "Qiymət 1-1000 arasında olmalıdır")]
        [Compare("Price", ErrorMessage = "Qiymətlər uyğun deyil")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}

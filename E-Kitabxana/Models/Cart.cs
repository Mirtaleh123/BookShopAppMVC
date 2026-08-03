using E_Kitabxana.Models;

namespace E_Kitabxana.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "";
        public int BookId { get; set; }
        public int Quantity { get; set; } = 1;

        public Book Book { get; set; } = null!;  // ✅ bu yox idi
    }
}
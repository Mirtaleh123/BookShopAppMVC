namespace E_Kitabxana.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string About { get; set; } = string.Empty;
        public int CategoryId {  get; set; }
        public Category Category { get; set; } = null!;
        public int Stock { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
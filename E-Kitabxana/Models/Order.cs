namespace E_Kitabxana.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "";
        public DateTime OrderDate { get; set; }= DateTime.Now;
        public string Status { get; set; } = "Gözləyir";
        public decimal TotalPrice {  get; set; }
        public List<OrderItem> OrderItems { get; set; } = new();
    }
}

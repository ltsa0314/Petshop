namespace PetShop.Api.Dtos
{
    public class OrderItemDto
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

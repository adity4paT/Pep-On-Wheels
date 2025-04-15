namespace Pep_On_Wheels.DTO.Order
{
    public class OrderItemReadDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

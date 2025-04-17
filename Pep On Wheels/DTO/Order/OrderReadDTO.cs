namespace Pep_On_Wheels.DTO.Order
{
    public class OrderReadDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItemReadDTO> OrderItems { get; set; }
    }
}

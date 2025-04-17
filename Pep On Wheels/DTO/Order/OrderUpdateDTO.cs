namespace Pep_On_Wheels.DTO.Order
{
    public class OrderUpdateDTO
    {
        public decimal TotalAmount { get; set; }
        public List<OrderItemUpdateDTO> OrderItems { get; set; }
    }
}

namespace Pep_On_Wheels.DTO.Order
{
    public class OrderCreateDTO
    {
        public int UserId { get; set; }
        public List<OrderItemReadDTO> Items { get; set; }
    }
}

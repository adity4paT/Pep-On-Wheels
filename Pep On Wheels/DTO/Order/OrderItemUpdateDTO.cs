namespace Pep_On_Wheels.DTO.Order
{
    public class OrderItemUpdateDTO
    {
        public int Id { get; set; } // To identify the item
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}

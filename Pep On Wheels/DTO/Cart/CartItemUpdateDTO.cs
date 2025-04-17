namespace Pep_On_Wheels.DTO.Cart
{
    public class CartItemUpdateDTO
    {
        int Id { get; set; }          // Required to identify which item to update
        int Quantity { get; set; }
    }
}

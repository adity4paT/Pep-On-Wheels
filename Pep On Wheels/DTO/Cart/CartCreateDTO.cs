namespace Pep_On_Wheels.DTO.Cart
{
    public class CartCreateDTO
    {
        int UserId { get; set; }
        List<CartItemCreateDTO> CartItems { get; set; }
    }
}

namespace Pep_On_Wheels.DTO.Cart
{
    public class CartReadDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CartItemDetailDTO> CartItems { get; set; }
    }
}

namespace Pep_On_Wheels.DTO.ProductImage
{
    public class ProductImageDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; } = string.Empty; 
        public string? Description { get; set; }
    }
}

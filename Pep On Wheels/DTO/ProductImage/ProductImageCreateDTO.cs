namespace Pep_On_Wheels.DTO.ProductImage
{
    public class ProductImageCreateDTO
    {
        public string Url { get; set; } = string.Empty;     
        public string Description { get; set; } = string.Empty;
        public int ProductId { get; set; }
    }
}

namespace Pep_On_Wheels.DTO.Product
{
    public class ProductUpdateDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public int? CategoryId { get; set; }
    }
}

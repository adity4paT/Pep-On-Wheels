namespace Pep_On_Wheels.DTO.Product
{
    public class ProductReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public double Rating { get; set; }

        public string CategoryName { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
    }
}

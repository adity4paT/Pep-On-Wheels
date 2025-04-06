using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Pep_On_Wheels.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Stock { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public double Rating { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}

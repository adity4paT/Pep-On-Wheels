using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pep_On_Wheels.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

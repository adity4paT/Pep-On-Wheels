using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pep_On_Wheels.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string ContactNumber { get; set; }

        public string CountryCode { get; set; }

        public ICollection<Address> Addresses { get; set; }

        public ICollection<Order> Orders { get; set; }

        public Cart Cart { get; set; }
    }
}

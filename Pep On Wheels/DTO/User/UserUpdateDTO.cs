using System.ComponentModel.DataAnnotations;

namespace Pep_On_Wheels.DTO.User
{
    public class UserUpdateDTO
    {
        [Required]
        int Id { get; set; }          // Required to identify the user
        string? Name { get; set; }                // Nullable = optional update
        string? ContactNumber { get; set; }       // Nullable = optional update
        string? CountryCode { get; set; }        // Nullable = optional update
    }
}

namespace Pep_On_Wheels.DTO.User
{
    public class UserCreateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? CountryCode { get; set; }
    }
}

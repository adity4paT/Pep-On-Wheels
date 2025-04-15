namespace Pep_On_Wheels.DTO.Address
{
    public class AddressCreateDTO
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int UserId { get; set; }
    }
}

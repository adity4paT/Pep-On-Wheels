namespace Pep_On_Wheels.DTO.Address
{
    public class AddressUpdateDTO
    {
        public int Id { get; set; } // needed to identify which address to update

        public string Street { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public int UserId { get; set; } // foreign key
    }
}

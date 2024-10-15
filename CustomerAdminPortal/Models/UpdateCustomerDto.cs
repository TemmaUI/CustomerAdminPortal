namespace CustomerAdminPortal.Models
{
    public class UpdateCustomerDto
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public string? City { get; set; }
    }
}

namespace apartment_portal_api.DTOs
{
    public class UserDTO
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int StatusId { get; set; }
    }

    public class RegistrationRequestDTO
    {
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required int StatusId { get; set; }
        public required string CreatedBy { get; set; }
        public required string ModifiedBy { get; set; }
        public required string Password { get; set; }
    }
}
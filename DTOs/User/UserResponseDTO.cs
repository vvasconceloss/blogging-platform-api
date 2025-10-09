namespace bloggin_plataform_api.DTOs.User
{
    public class UserResponseDTO
    {
        public required int Id { get; set; }
        public required string Username { get; set; }
        public required string EmailAddress { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
    }
}
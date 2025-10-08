namespace bloggin_plataform_api.DTOs.User
{
    public class UserDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string EmailAddress { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
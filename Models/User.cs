namespace bloggin_plataform_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string EmailAdress { get; set; }
        public required string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
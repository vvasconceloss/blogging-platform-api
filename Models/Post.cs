namespace bloggin_plataform_api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public required int UserId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
namespace Hated.Infrastructure.DTO
{
    public class PostDto
    {
        public int Id { get; set; }
        public UserDto Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CountLikes { get; set; }
        public bool Activated { get; set; }
    }
}

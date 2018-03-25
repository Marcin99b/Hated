using System;

namespace Hated.Infrastructure.DTO
{
    public class PostDto
    {
        public string Id { get; set; }
        public UserDto Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CountLikes { get; set; }
        public bool Activated { get; set; }
    }
}

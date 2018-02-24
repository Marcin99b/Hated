using System;

namespace Hated.Infrastructure.DTO
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public UserDto Author { get; set; }
        public bool Activated { get; set; }
        public string Content { get; set; }
    }
}

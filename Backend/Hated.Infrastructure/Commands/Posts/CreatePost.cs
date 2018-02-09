using System;

namespace Hated.Infrastructure.Commands.Posts
{
    public class CreatePost
    {
        public Guid UserId { get; set; }
        public string Content { get; set; }
    }
}

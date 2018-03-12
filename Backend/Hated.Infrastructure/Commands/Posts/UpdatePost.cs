using System;

namespace Hated.Infrastructure.Commands.Posts
{
    public class UpdatePost
    {
        public Guid Id { get; set; }
        public Guid Author { get; set; }
        public string Content { get; set; }
    }
}

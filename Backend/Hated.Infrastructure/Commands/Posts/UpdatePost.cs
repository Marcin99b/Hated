using System;

namespace Hated.Infrastructure.Commands.Posts
{
    public class UpdatePost
    {
        public int Id { get; set; }
        public Guid Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}

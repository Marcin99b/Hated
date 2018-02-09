using System;

namespace Hated.Infrastructure.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
    }
}

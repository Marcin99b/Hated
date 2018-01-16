using System;
using System.Collections.Generic;

namespace Hated.Infrastructure.DTO
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }

    }
}

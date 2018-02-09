using System;

namespace Hated.Infrastructure.Commands.Comment
{
    public class CreateComment
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Content { get; set; }
    }
}

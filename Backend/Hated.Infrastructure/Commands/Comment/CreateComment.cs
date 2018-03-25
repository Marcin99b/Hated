using System;

namespace Hated.Infrastructure.Commands.Comment
{
    public class CreateComment
    {
        public string PostId { get; set; }
        public string Content { get; set; }
    }
}

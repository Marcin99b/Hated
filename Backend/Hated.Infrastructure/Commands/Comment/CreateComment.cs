using System;

namespace Hated.Infrastructure.Commands.Comment
{
    public class CreateComment
    {
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}

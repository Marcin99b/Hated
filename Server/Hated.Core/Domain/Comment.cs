using System;

namespace Hated.Core.Domain
{
    public class Comment
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Content { get; protected set; }
        public DateTime ChangedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public Comment(Guid userId, string content)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            SetContent(content);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetContent(string content)
        {
            Content = content;
            ChangedAt = DateTime.UtcNow;
        }
    }
}

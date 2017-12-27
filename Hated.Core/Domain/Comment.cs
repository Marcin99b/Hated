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

        public Comment(User user, string content)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
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

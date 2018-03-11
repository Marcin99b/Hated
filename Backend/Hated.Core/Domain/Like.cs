using System;

namespace Hated.Core.Domain
{
    public class Like
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public DateTime CreateAt { get; protected set; }

        public Like(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            CreateAt = DateTime.UtcNow;
        }
    }
}

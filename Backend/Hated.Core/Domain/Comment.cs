using System;
using System.Collections.Generic;
using System.Linq;

namespace Hated.Core.Domain
{
    public class Comment : ISort
    {
        private ISet<Like> _likes = new HashSet<Like>();

        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Content { get; protected set; }
        public IEnumerable<Like> Likes
        {
            get => _likes;
            protected set => _likes = new HashSet<Like>(value);
        }
        public int CountLikes => _likes.Count;
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

        public void AddLike(Guid userId)
        {
            _likes.Add(new Like(userId));
        }

        public void DeleteLike(Guid userId)
        {
            var like = Likes.FirstOrDefault(x => x.Id == userId);
            _likes.Remove(like);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Hated.Core.Domain
{
    public class Post : ISort
    {
        private ISet<Comment> _comments = new HashSet<Comment>();

        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Content { get; protected set; }
        public IEnumerable<Comment> Comments
        {
            get => _comments;
            set => _comments = new HashSet<Comment>(value);
        }
        public bool Activated { get; protected set; }
        public DateTime ChangedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public Post(Guid userId, string content)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            SetContent(content);
            Deactivate();
            CreatedAt = DateTime.UtcNow;
        }

        public void SetContent(string content)
        {
            Content = content;
            ChangedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            Activated = true;
            ChangedAt = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            Activated = false;
            ChangedAt = DateTime.UtcNow;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
            CreatedAt = DateTime.UtcNow;
        }

        public Comment GetComment(Guid commentId)
            => Comments.SingleOrDefault(x => x.Id == commentId);


        public void UpdateComment(Comment comment)
        {
            _comments.Where(x => x.Id == comment.Id).Select(x => comment).ToHashSet();
            CreatedAt = DateTime.UtcNow;
        }
        
        public void DeleteComment(Comment comment)
        {
            _comments.Remove(comment);

            CreatedAt = DateTime.UtcNow;
        }
    }
}

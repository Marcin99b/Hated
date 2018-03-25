using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hated.Core.Domain
{
    public class Post : ISort
    { 
        private ISet<Comment> _comments = new HashSet<Comment>();
        private ISet<Like> _likes = new HashSet<Like>();
        private ISet<UpdateByAdmin> _updatesByAdmins = new HashSet<UpdateByAdmin>();

        public string Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Title { get; protected set; }
        public string Content { get; protected set; }
        public IEnumerable<Comment> Comments
        {
            get => _comments;
            protected set => _comments = new HashSet<Comment>(value);
        }
        public IEnumerable<Like> Likes
        {
            get => _likes;
            protected set => _likes = new HashSet<Like>(value);
        }
        public int CountLikes => _likes.Count;
        public bool Activated { get; protected set; }
        public IEnumerable<UpdateByAdmin> UpdatesByAdmins
        {
            get => _updatesByAdmins;
            protected set => _updatesByAdmins = new HashSet<UpdateByAdmin>(value);
        }
        public DateTime ChangedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public Post(Guid userId, string title, string content)
        {
            Id = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            UserId = userId;
            SetContent(content);
            Deactivate();
            CreatedAt = DateTime.UtcNow;
        }

        public void SetTitle(string title)
        {
            Title = title;
            ChangedAt = DateTime.UtcNow;
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

        public void UpdateByAdmin(Guid adminId, string comment)
        {
            _updatesByAdmins.Add(new UpdateByAdmin(adminId, comment));
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

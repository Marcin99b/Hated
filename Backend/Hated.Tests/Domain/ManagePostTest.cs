using System;
using System.Linq;
using Hated.Core.Domain;
using Xunit;

namespace Hated.Tests.Domain
{
    public class ManagePostTest
    {
        [Fact]
        public void WhenPostIsUpdatedListShouldBeUpdated()
        {
            string beforeText = "before";
            string afterText = "after";

            var user = new User("test@test.com", "secret", "secret123", "salt");

            var post = new Post(user.Id, Guid.NewGuid().ToString(), Guid.NewGuid().ToString() + Guid.NewGuid());
            var comment = new Comment(user.Id, beforeText);

            post.AddComment(comment);

            //Check did post was created and put to list (ienumerable)
            Assert.Equal(beforeText, post.Comments.Single(x => x.Id == comment.Id).Content);

            comment.SetContent(afterText);
            post.UpdateComment(comment);

            //Did list (ienumerable) was updated, after update post
            Assert.Equal(afterText, post.Comments.Single(x => x.Id == comment.Id).Content);
        }
    }
}

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

            var post = new Post(new User(), "test");
            var comment = new Comment(new User(), beforeText);

            post.AddComment(comment);

            //Check did post was created and put to list (ienumerable)
            Assert.Equal(post.Comments.Single(x => x.Id == comment.Id).Content, beforeText);

            comment.SetContent(afterText);
            post.UpdateComment(comment);

            //Did list (ienumerable) was updated, after update post
            Assert.Equal(post.Comments.Single(x => x.Id == comment.Id).Content, afterText);
        }
    }
}

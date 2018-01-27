using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Hates.Tests.EndToEnd
{
    public class CrudCommentTest : BaseMethodsToTests
    {
        [Fact]
        public async Task CreatedCommentShouldBeCreatedAndValid()
        {
            var user = await CreateAndGetRandomUser();
            var responsePost = await CreateNewPost(user.Id);
            var post = await GetPostAsync(responsePost.Headers.Location.ToString());
            var responseComment = await CreateNewComment(user.Id, post.Id, Guid.NewGuid().ToString());

            Assert.Equal(HttpStatusCode.Created, responseComment.StatusCode);
            var comment = await GetCommentAsync(responseComment.Headers.Location.ToString());
            Assert.Equal(user.Id, comment.UserId);
        }

        [Fact]
        public async Task UpdatedCommentShouldBeUpdated()
        {
            var post = await CreateAndGetRandomPost();
            var comment = await CreateAndGetRandomComment(post);
            string updatedContent = "testcontent";
            comment.Content = updatedContent;
            var payload = GetPayload(comment);
            var response = await Client.PutAsync($"api/comments/post/{post.Id}", payload);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var updatedComment = await GetCommentAsync($"api/comments/{comment.Id}");
            Assert.Equal(updatedContent, updatedComment.Content);
        }

        [Fact]
        public async Task DeletedCommentShouldBeDeleted()
        {
            var post = await CreateAndGetRandomPost();
            var comment = await CreateAndGetRandomComment(post);
            var responseDeleted = await Client.DeleteAsync($"api/comments/post/{post.Id}/comment/{comment.Id}");
            Assert.Equal(HttpStatusCode.OK, responseDeleted.StatusCode);
        }
    }
}

using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Hated.Tests.EndToEnd
{
    public class CrudCommentTest : BaseMethodsToTests
    {

        [Fact]
        public async Task CreatedCommentShouldBeCreatedAndValid()
        {
            var responsePost = await CreateNewPost(testUserGenerate.Id);
            var post = await GetPostAsync(responsePost.Headers.Location.ToString());
            var responseComment = await CreateNewComment(testUserGenerate.Id, post.Id, Guid.NewGuid().ToString());

            Assert.Equal(HttpStatusCode.Created, responseComment.StatusCode);
            var comment = await GetCommentAsync(responseComment.Headers.Location.ToString());
            Assert.Equal(testUserGenerate.Id, comment.UserId);
        }

        [Fact]
        public async Task UpdatedCommentShouldBeUpdated()
        {
            var post = await CreateAndGetRandomPost(testUserGenerate);
            var comment = await CreateAndGetRandomComment(post, testUserGenerate);
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
            var post = await CreateAndGetRandomPost(testUserGenerate);
            var comment = await CreateAndGetRandomComment(post, testUserGenerate);
            var responseDeleted = await Client.DeleteAsync($"api/comments/post/{post.Id}/comment/{comment.Id}");
            Assert.Equal(HttpStatusCode.OK, responseDeleted.StatusCode);
        }
    }
}

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
            var responsePost = await CreateNewPost();
            var post = await GetPostAsync(responsePost.Headers.Location.ToString());
            var responseComment = await CreateNewComment(post.Id, await GetRandomTextAsync());

            Assert.Equal(HttpStatusCode.Created, responseComment.StatusCode);
            var comment = await GetCommentAsync(responseComment.Headers.Location.ToString());
            Assert.Equal(testUserGenerate.Id, comment.UserId);
        }

        [Fact]
        public async Task UpdatedCommentShouldBeUpdated()
        {
            var post = await CreateAndGetRandomPost(testUserGenerate);
            var comment = await CreateAndGetRandomComment(post, testUserGenerate);
            string updatedContent = await GetRandomTextAsync();
            comment.Content = updatedContent;
            var payload = GetPayload(comment);
            var response = await Client.PutAsync($"comments/post/{post.Id}", payload);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var updatedComment = await GetCommentAsync($"comments/{comment.Id}");
            Assert.Equal(updatedContent, updatedComment.Content);
        }

        [Fact]
        public async Task DeletedCommentShouldBeDeleted()
        {
            var post = await CreateAndGetRandomPost(testUserGenerate);
            var comment = await CreateAndGetRandomComment(post, testUserGenerate);
            var responseDeleted = await Client.DeleteAsync($"comments/post/{post.Id}/comment/{comment.Id}");
            Assert.Equal(HttpStatusCode.OK, responseDeleted.StatusCode);
        }
    }
}

using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Hates.Tests.EndToEnd
{
    public class CrudPostTest : BaseMethodsToTests
    {
        [Fact]
        public async Task CreatedPostShouldBeCreated()
        {
            var user = await CreateAndGetRandomUser();
            var response = await CreateNewPost(user.Id);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task CreatedPostShouldBeValid()
        {
            var user = await CreateAndGetRandomUser();
            string content = Guid.NewGuid().ToString();
            var response = await CreateNewPost(user.Id, content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var post = await GetPostAsync(response.Headers.Location.ToString());
            Assert.Equal(user.Id, post.UserId);
            Assert.Equal(content, post.Content);
        }

        [Fact]
        public async Task UpdatedPostShouldBeUpdated()
        {
            var user = await CreateAndGetRandomUser();
            var response = await CreateNewPost(user.Id);
            var post = await GetPostAsync(response.Headers.Location.ToString());
            string updatedPostContent = Guid.NewGuid().ToString();
            post.Content = updatedPostContent;
            var payload = GetPayload(post);
            await Client.PutAsync("api/posts", payload);
            var updatedPost = await GetPostAsync(response.Headers.Location.ToString());
            Assert.Equal(updatedPostContent, updatedPost.Content);

        }

        [Fact]
        public async Task DeletedPostShouldBeDeleted()
        {
            var user = await CreateAndGetRandomUser();
            var response = await CreateNewPost(user.Id);
            var responseDeleted = await Client.DeleteAsync(response.Headers.Location.ToString());
            Assert.Equal(HttpStatusCode.OK, responseDeleted.StatusCode);
        }
    }
}

using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Hated.Tests.EndToEnd
{
    public class CrudPostTest : BaseMethodsToTests
    {
        [Fact]
        public async Task CreatedPostShouldBeCreated()
        {
            var response = await CreateNewPost();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task CreatedPostShouldBeValid()
        {
            string content = await GetRandomTextAsync();
            var response = await CreateNewPost(content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var post = await GetPostAsync(response.Headers.Location.ToString());
            Assert.Equal(testUserGenerate.Id, post.Author.Id);
            Assert.Equal(content, post.Content);
        }

        [Fact]
        public async Task UpdatedPostShouldBeUpdated()
        {
            var response = await CreateNewPost();
            var post = await GetPostAsync(response.Headers.Location.ToString());
            string updatedPostContent = await GetRandomTextAsync();
            post.Content = updatedPostContent;
            var payload = GetPayload(post);
            await Client.PutAsync("posts", payload);
            var updatedPost = await GetPostAsync(response.Headers.Location.ToString());
            Assert.Equal(updatedPostContent, updatedPost.Content);

        }

        [Fact]
        public async Task DeletedPostShouldBeDeleted()
        {
            var response = await CreateNewPost();
            var responseDeleted = await Client.DeleteAsync(response.Headers.Location.ToString());
            Assert.Equal(HttpStatusCode.OK, responseDeleted.StatusCode);
        }
    }
}

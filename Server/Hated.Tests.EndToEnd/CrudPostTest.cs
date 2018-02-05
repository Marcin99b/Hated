﻿using System;
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
            var response = await CreateNewPost(testUserGenerate.Id);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task CreatedPostShouldBeValid()
        {
            string content = Guid.NewGuid().ToString();
            var response = await CreateNewPost(testUserGenerate.Id, content);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var post = await GetPostAsync(response.Headers.Location.ToString());
            Assert.Equal(testUserGenerate.Id, post.UserId);
            Assert.Equal(content, post.Content);
        }

        [Fact]
        public async Task UpdatedPostShouldBeUpdated()
        {
            var response = await CreateNewPost(testUserGenerate.Id);
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
            var response = await CreateNewPost(testUserGenerate.Id);
            var responseDeleted = await Client.DeleteAsync(response.Headers.Location.ToString());
            Assert.Equal(HttpStatusCode.OK, responseDeleted.StatusCode);
        }
    }
}

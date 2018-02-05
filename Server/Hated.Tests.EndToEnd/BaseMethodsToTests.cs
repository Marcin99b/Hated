using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Hated.Infrastructure.Commands.Comment;
using Hated.Infrastructure.Commands.Posts;
using Hated.Infrastructure.Commands.Users;
using Hated.Infrastructure.DTO;
using Newtonsoft.Json;

namespace Hates.Tests.EndToEnd
{
    public class BaseMethodsToTests : ServerConfigAndRun
    {
        protected StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        #region User
        //User
        protected async Task<HttpResponseMessage> CreateNewUser(string email, string username = null)
        {
            username = username ?? "testuser";
            var payload = GetPayload(new CreateUser
            {
                Email = email,
                Username = username,
                Password = "secret"
            });
            return await Client.PostAsync("api/users", payload);
        }

        protected async Task<UserDto> GetUserAsync(string email)
        {
            var response = await Client.GetAsync($"api/users/{email}");
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<UserDto>(responseString);
        }

        protected async Task<UserDto> CreateAndGetRandomUser()
        {
            string emailTestedUser = Guid.NewGuid().ToString();
            await CreateNewUser(emailTestedUser);
            return await GetUserAsync(emailTestedUser);
        }
        #endregion

        #region Post
        //Post
        protected async Task<HttpResponseMessage> CreateNewPost(Guid userId, string content = null)
        {
            content = content ?? "testcontent";
            var payload = GetPayload(new CreatePost
            {
                UserId = userId,
                Content = content
            });
            return await Client.PostAsync("api/posts", payload);
        }

        protected async Task<PostDto> GetPostAsync(string location)
        {
            var response = await Client.GetAsync(location);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<PostDto>(responseString);
        }

        protected async Task<PostDto> CreateAndGetRandomPost()
        {
            var user = await CreateAndGetRandomUser();
            var responsePost = await CreateNewPost(user.Id);
            return await GetPostAsync(responsePost.Headers.Location.ToString());
        }
        #endregion

        #region Comment
        //Comment
        protected async Task<HttpResponseMessage> CreateNewComment(Guid userId, Guid postId, string content)
        {
            var payload = GetPayload(new CreateComment
            {
                UserId = userId,
                PostId = postId,
                Content = content
            });
            return await Client.PostAsync("api/comments", payload);
        }

        protected async Task<CommentDto> GetCommentAsync(string location)
        {
            var response = await Client.GetAsync(location);
            var responseString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CommentDto>(responseString);
        }

        protected async Task<CommentDto> CreateAndGetRandomComment(PostDto post)
        {
            var user = await CreateAndGetRandomUser();
            var responseComment = await CreateNewComment(user.Id, post.Id, Guid.NewGuid().ToString());
            return await GetCommentAsync(responseComment.Headers.Location.ToString());
        }

        #endregion
    }
}

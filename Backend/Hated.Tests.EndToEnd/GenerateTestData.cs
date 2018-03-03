using System;
using System.Threading.Tasks;
using Xunit;

namespace Hated.Tests.EndToEnd
{
    public class GenerateTestData : BaseMethodsToTests
    {
        //[Fact]
        public async Task CreatePostsWithComments()
        {
            var random = new Random();
            for (var i = 0; i < 200; i++)
            {
                var responsePost = await CreateNewPost();
                var post = await GetPostAsync(responsePost.Headers.Location.ToString());
                for (var j = 0; j < random.Next(3, 5); j++)
                {
                    await CreateNewComment(post.Id);
                }
            }
        }

        //[Fact]
        public async Task CreatePostsWithoutComments()
        {
            for (var i = 0; i < 200; i++)
            {
                await CreateNewPost();
            }
        }
    }
}

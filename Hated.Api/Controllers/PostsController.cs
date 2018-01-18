using Hated.Infrastructure.Services;

namespace Hated.Api.Controllers
{
    public class PostsController : BaseController
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

    }
}

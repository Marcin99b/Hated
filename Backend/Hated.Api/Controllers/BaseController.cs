using Microsoft.AspNetCore.Mvc;

namespace Hated.Api.Controllers
{
	[EnableCors("AllowAny")]
    [Produces("application/json")]
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
        }
    }
}

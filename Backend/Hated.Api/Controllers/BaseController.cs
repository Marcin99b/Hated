using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Hated.Api.Controllers
{
	[EnableCors("AllowAny")]
    [Produces("application/json")]
    [Route("[controller]")]
    [EnableCors("AllowAny")]
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
        }
    }
}

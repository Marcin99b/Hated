using Microsoft.AspNetCore.Mvc;

namespace Hated.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
        }
    }
}

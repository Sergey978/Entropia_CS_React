using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entropia_CS_React.Entities;

namespace Entropia_CS_React.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        public Account Account => (Account)HttpContext.Items["Account"];
    }
}

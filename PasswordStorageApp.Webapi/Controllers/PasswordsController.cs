using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PasswordStorageApp.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        [HttpGet]
        public string Get() 
        {
            return "Hello World";
        }
    }
}

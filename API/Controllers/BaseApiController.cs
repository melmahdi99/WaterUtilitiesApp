using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController<T> : ControllerBase
    {
        protected readonly ILogger<T> _logger;
        protected BaseApiController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}

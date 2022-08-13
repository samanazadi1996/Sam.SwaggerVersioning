using Microsoft.AspNetCore.Mvc;

namespace Sam.SwaggerVersioning.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController : ControllerBase
    {
    }
}

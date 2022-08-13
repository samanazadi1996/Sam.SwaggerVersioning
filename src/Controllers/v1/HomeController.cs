using Microsoft.AspNetCore.Mvc;

namespace Sam.SwaggerVersioning.Controllers.v1
{
    [ApiVersion("1.0")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Get() => Ok(typeof(HomeController).FullName);
    }
}

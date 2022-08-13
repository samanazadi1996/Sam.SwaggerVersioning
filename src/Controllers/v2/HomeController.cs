using Microsoft.AspNetCore.Mvc;

namespace Sam.SwaggerVersioning.Controllers.v2
{
    [ApiVersion("2.0")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Get() => Ok(typeof(HomeController).FullName);
    }
}

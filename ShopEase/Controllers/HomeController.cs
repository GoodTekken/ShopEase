using Microsoft.AspNetCore.Mvc;

namespace ShopEase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 测试主页内容
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "Index")]
        public IActionResult Index()
        {
            return Ok("Welcome to ShopEase!");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopEase.Controllers
{
    //[Route("api/[controller]")]  //默认路径，网络请求路径为api/controller文件名，如果有多个方法则会冲突
    //[Route("[controller]")]      //仿照其他文件的路由格式
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string WebApiTest()
        {
            return "Hello World!";
        }

        [HttpGet]   
        public string WebApiTest2()
        {
            return "Hello World2!";
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherCast.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConfController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Get()
        {
            return _configuration.GetValue<string>("Key");
        }
    }
}

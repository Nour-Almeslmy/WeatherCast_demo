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

        [HttpGet]
        public string Get()
        {
            return _configuration.GetValue<string>("Key");
        }

        [HttpGet]
        [Route("env")]
        public string GetFromEnvValues()
        {
            var value = _configuration.GetValue<string>("fromEnv");
            if (String.IsNullOrEmpty(value)) 
            {
                return "Empty Value From Environment";
            }
            return value;
        }

        [HttpGet]
        [Route("map")]
        public string GetFromConfMap()
        {
            var value = _configuration.GetValue<string>("fromConfMap");
            if (String.IsNullOrEmpty(value))
            {
                return "Empty Value From ConfMap";
            }
            return value;
        }

        [HttpGet]
        [Route("cs")]
        public string GetConectionString()
        {
            return _configuration.GetConnectionString("default");
        }

        [HttpGet]
        [Route("csOrange")]
        public string GetConectionStringOrange() 
        {
            return _configuration.GetValue<string>("orangeDB");
        }

        [HttpGet]
        [Route("csOrangeCash")]
        public string GetConectionStringOC()
        {
            return _configuration.GetValue<string>("orange-cash-cs-fromSecret");
        }
    }
}

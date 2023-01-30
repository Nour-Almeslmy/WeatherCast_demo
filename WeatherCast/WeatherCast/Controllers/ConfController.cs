using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherCast.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConfController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public ConfController(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
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

        [HttpGet]
        [Route("file")]
        public string GetValueFromConfFile()
        {
            var value = _configuration.GetValue<string>("confKey");
            if (String.IsNullOrEmpty(value))
            {
                return "Empty Value From conf file";
            }
            return value;
        }

        [HttpGet]
        [Route("secretun")]
        public string GetValueFromSecretUserName()
        {
            var value = _configuration.GetValue<string>("userName");
            if (String.IsNullOrEmpty(value))
            {
                return "Empty value from secret";
            }
            return value;
        }

        [HttpGet]
        [Route("secretp")]
        public string GetValueFromSecretPassword()
        {
            var value = _configuration.GetValue<string>("password");
            if (String.IsNullOrEmpty(value))
            {
                return "Empty value from secret";
            }
            return value;
        }

        [HttpGet]
        [Route("log")]
        public string Log() 
        {
            try
            {
                string? error = null;
                error.ToUpper();
            }
            catch (Exception exp)
            {
                _logger.LogError($"Message : {exp.Message}"+
                    $"InnerException : {exp.InnerException}"+
                    $"StackTree : {exp.StackTrace}");
            }
            return "Logging";
        }

    }
}

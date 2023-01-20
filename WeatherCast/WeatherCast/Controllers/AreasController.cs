﻿using AreasUtils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherCast.Common.Entities;

namespace WeatherCast.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class AreasController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Area> Get()
        {
            var areas = GetAreas();

            return areas;
        }

        [HttpGet]
        [Route("per")]
        public string GetAreaperimeter()
        {
            var area = new AerasDims(3, 5);

            return area.perimeter.ToString();
        }

        private List<Area> GetAreas()
        {
            return new List<Area>
            {
                new Area("Cairo", "Sunny"),
                new Area("Alex", "Cloudy")
            };
        }
    }
}

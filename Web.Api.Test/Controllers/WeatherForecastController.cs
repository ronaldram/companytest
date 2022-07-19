﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using Application.Business;

namespace Web.Api.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezings", 
            "Bracings", 
            "Chillys", 
            "Cool",
            "Mild",
            "Warm", "Balmsy", "Hots", "Swelterings", "Scorchings"
        };


        public NameValueCollection _settginsCollection;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _settginsCollection = new NameValueCollection()
            {
                { "key1", "value1" },
                { "key2", "value2" },
                { "key3", "value3" }
            };
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            var value = _settginsCollection["key1"];

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IEnumerable<CustomerModel> GetCustomer()
        {
            var business = new CustomerBusiness();
            return business.GetAll();
        }
    }
}

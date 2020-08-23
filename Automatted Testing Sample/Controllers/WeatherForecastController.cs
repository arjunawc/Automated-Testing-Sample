using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Automatted_Testing_Sample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Automatted_Testing_Sample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IForecast m_forecast;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IForecast forecast)
        {
            _logger = logger;
            m_forecast = forecast;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return m_forecast.Get();
        }
    }
}

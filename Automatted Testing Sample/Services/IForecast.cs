using System.Collections.Generic;

namespace Automatted_Testing_Sample.Services
{
    public interface IForecast
    {
        IEnumerable<WeatherForecast> Get();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automatted_Testing_Sample.Repositories
{
    public class Summaries : ISummaries
    {
        public IList<string> WeatherSummaries { get; }

        public Summaries()
        {
            WeatherSummaries = new List<string>() { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        }
    }
}

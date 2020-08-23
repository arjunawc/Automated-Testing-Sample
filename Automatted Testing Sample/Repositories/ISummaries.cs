using System.Collections.Generic;

namespace Automatted_Testing_Sample.Repositories
{
    public interface ISummaries
    {
        IList<string> WeatherSummaries { get; }
    }
}
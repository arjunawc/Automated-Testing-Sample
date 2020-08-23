using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Automatted_Testing_Sample.Repositories
{
    public class Weather : IWeather
    {
        private readonly Random m_rng;

        public Weather()
        {
            m_rng = new Random();

        }
        public int GetTemperature(int day)
        {
            return m_rng.Next(-20, 55);
        }
    }
}

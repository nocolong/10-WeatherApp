using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core.Domain
{
    public class ConditionsResult
    {
        public string weather { get; set; }
        public float temp_f { get; set; }
        public float temp_c { get; set; }
        public DisplayLocation display_location { get; set; }
        public string relative_humidity { get; set; }
        public double UV { get; set; }
        public string observation_time { get; set; }
        public string icon_url { get; set; }
        public string icon { get; set; }
        

    }
}

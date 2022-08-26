using System;
namespace Weather.InteractiveForecastAPI.Models
{
    public class IAForecastRequest
    {
       public int days { get; set; }
        public string aqi { get; set; }
        public string alerts { get; set;}
        public string city { get; set; }
    }
}


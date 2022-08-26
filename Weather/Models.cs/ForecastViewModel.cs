using System;
using System.ComponentModel.DataAnnotations;

//Index viewmodel
namespace Weather.Models
{
    public class ForecastViewModel
    {
        [Required(ErrorMessage = "(This field can not be empty.)")]
        public string city { get; set; }

        public List<ForecastdayView> forecastDetail { get; set; }
    }

    public class ForecastdayView
    {
        public string date { get; set; }
        public DayView day { get; set; }
    }
    public class DayView
    {
        public double maxtemp_c { get; set; }
        public double mintemp_c { get; set; }
        public double avgtemp_c { get; set; }
        public double maxwind_mph { get; set; }
        public double totalprecip_mm { get; set; }
        public double totalprecip_in { get; set; }
        public double avgvis_km { get; set; }
        public double avgvis_miles { get; set; }
        public double avghumidity { get; set; }
        public int daily_will_it_rain { get; set; }
        public int daily_chance_of_rain { get; set; }
        public int daily_will_it_snow { get; set; }
        public int daily_chance_of_snow { get; set; }
        public ConditionView condition { get; set; }
        public double uv { get; set; }
    }
    public class ConditionView
    {
        public string text { get; set; }
        public string icon { get; set; }
        public int code { get; set; }
    }
}


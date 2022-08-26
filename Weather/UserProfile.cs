using System;
using AutoMapper;
using Weather.InteractiveForecastAPI.Models;
using Weather.Dto;
using Weather.Models;

namespace Weather
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<Forecastday,ForecastdayDTO>();
            CreateMap<Day, DayDTO>();
            CreateMap<Condition, ConditionDTO>();
            CreateMap<ForecastdayDTO, ForecastdayView>();
            CreateMap<DayDTO, DayView>();
            CreateMap<ConditionDTO, ConditionView>();
        }
    }
}


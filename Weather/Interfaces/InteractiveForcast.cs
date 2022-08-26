using System;
using Weather.Dto;
using Weather.InteractiveForecastAPI.Models;

namespace Weather.Interfaces
{
    public interface IIAForecast
    {
        Task<List<ForecastdayDTO>> GetIAForecastAsync(IAForecastRequest request);
    }
}


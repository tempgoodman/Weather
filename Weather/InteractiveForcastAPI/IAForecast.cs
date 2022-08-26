
using System;
using Weather.Controllers;
using Weather.Dto;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Weather.InteractiveForecastAPI.Models;
using System.Text;
using AutoMapper;
using Weather.Interfaces;
using System.Linq;

namespace Weather
{
    public class IAForecast : IIAForecast
    {
        public readonly IMapper _mapper;
        private IConfiguration _config;
        private readonly ILogger<HomeController> _logger;

        public IAForecast(IMapper mapper, ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _config = configuration;
            _mapper = mapper;
        }
        public async Task<List<ForecastdayDTO>> GetIAForecastAsync(IAForecastRequest request)
        {
            
            HttpClient client = new HttpClient();
            try
            {
                InteractiveForecastConfig config = new InteractiveForecastConfig();

                _config.GetSection("InteractiveForecast").Bind(config);

                string url = $"{config.endpoint}{config.forecastAPIEndpoint}?key={config.token}&q={request.city}&days={request.days.ToString()}&aqi={request.aqi}&alerts={request.alerts}";

                //send request to third party api to get the data
                HttpResponseMessage response = await client.GetAsync(url);
                
                response.EnsureSuccessStatusCode();

                //read content from response
                var content = await response.Content.ReadAsStringAsync();

                //Log the result which get from API
                _logger.LogInformation($"Request: {url} Repsonse: {content}");
                if (content != null)
                {
                    IAForecastResponse data = JsonConvert.DeserializeObject<IAForecastResponse>(content);

                    //map the response data to DTO class
                    var forecast = _mapper.Map<List<ForecastdayDTO>>(data.forecast.forecastday);
                    return forecast;
                }
                else
                    return new List<ForecastdayDTO>();
            }
            catch (HttpRequestException e)
            {
                //get http exception
                _logger.LogError("Http Exception Message :{0} ", e.Message);
                return null;
            }
            catch (Exception e)
            {
                //get all expection
                _logger.LogError("Expection Message :{0} ", e.Message);
                return null;
            }
        }
    }
}


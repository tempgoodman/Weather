using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Weather.Models;
using Weather.Interfaces;
using AutoMapper;
using Weather.InteractiveForecastAPI.Models;
using Weather.Dto;

namespace Weather.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IConfigurationRoot _config;
    private IIAForecast _iAforecast;
    public readonly IMapper _mapper;

    public HomeController(ILogger<HomeController> logger, IConfiguration configRoot, IIAForecast iAForecast, IMapper mapper)
    {
        _mapper = mapper;
        _logger = logger;
        _config = (IConfigurationRoot)configRoot;
        _iAforecast = iAForecast;
    }
    
    public  IActionResult Index ()
    {
        return View(null);
    }
    [HttpPost]
    public async Task<IActionResult> IndexAsync(ForecastViewModel vm)
    {
        if (string.IsNullOrEmpty(vm.city)) 
        {
            return View(null);
        }

        //get result from third API
        List<ForecastdayDTO> forecast = await _iAforecast.GetIAForecastAsync(new IAForecastRequest() { city = vm.city, alerts = "yes", aqi = "yes", days = 7 });

        ForecastViewModel forecastViewModel = new ForecastViewModel();
        forecastViewModel.forecastDetail = _mapper.Map<List<ForecastdayView>>(forecast);
        forecastViewModel.city = vm.city;
        return View("Index", forecastViewModel);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


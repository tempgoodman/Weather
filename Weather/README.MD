
Before run the application:

restore nuget be below command
"nuget restore weather.sln"

The application used .net core 6 and below package:

AutoMapper ( for mapping the class from api to dto and from dto to modelview)
AutoMApper.Extension.Microsoft ( for mapping the class from api to dto and from dto to modelview)
Serilog.AspNetCore (Powerful tool for logging, but at this moment I just logged the data to file)
Newtonsoft.Json (do json stuff)
System.Net.Http (for get the forecast from API)

1. The application is simply using DI to create the "IAForecast" class, automapper and the logger.
2. When the user clcick on the search button, it will send the data to controller.
3. The controller will through the DI to call "AIForecast".
4. "AIForecast" will send the http request to Interactive forecast endpoint to get the forecast and logged to a file by serilog.
5. After the passed the automapper, the data will pass to view and render to the user's browser.




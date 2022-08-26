
using Serilog;
using AutoMapper.Execution;
using Weather.InteractiveForecastAPI;
using Weather.Interfaces;
using Weather;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

//Add Automapper as service
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Add IAForecast as service
builder.Services.AddScoped<IIAForecast, IAForecast>();


var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();


builder.Logging.ClearProviders();

//Use serilog for logging
builder.Logging.AddSerilog(logger);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


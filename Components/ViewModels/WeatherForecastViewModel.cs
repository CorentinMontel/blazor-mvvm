using BlazorAppMVVM.Components.Model;

namespace BlazorAppMVVM.Components.ViewModels;

public class WeatherForecastViewModel : BaseViewModel
{
    private WeatherForecastModel weatherForecastModel = new WeatherForecastModel();
    private string[] summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    public WeatherForecastModel WeatherForecastModel
    {
        get => weatherForecastModel;
        private set
        {
            SetValue(ref weatherForecastModel, value);
        }
    }
    
    public async void FetchWeatherForecast()
    {
        IsBusy = true;
        // Simulate asynchronous loading to demonstrate streaming rendering
        await Task.Delay(500);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var newForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        }).ToArray();

        WeatherForecastModel.forecasts.Clear();
        foreach (var forecast in newForecasts)
        {
            WeatherForecastModel.forecasts.Add(forecast);
        }

        IsBusy = false;
    }
}

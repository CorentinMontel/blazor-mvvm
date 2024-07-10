using System.Collections.ObjectModel;
using BlazorAppMVVM.Components.Model;

namespace BlazorAppMVVM.Components.ViewModels;

public class WeatherForecastViewModel : BaseViewModel
{
    private readonly string[] _summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

    private WeatherForecastModel _weatherForecastModel = new WeatherForecastModel();

    public WeatherForecastModel WeatherForecastModel
    {
        get => _weatherForecastModel;
        private set => SetValue(ref _weatherForecastModel, value);
    }
    
    public async void FetchWeatherForecast()
    {
        IsBusy = true;
        WeatherForecastModel.Forecasts.Clear();
        // Simulate asynchronous loading to demonstrate streaming rendering
        await Task.Delay(500);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var newForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[Random.Shared.Next(_summaries.Length)]
        });

        WeatherForecastModel.Forecasts = new ObservableCollection<WeatherForecast>(newForecasts);
        WeatherForecastModel.CollectionLength = newForecasts.Count();
        IsBusy = false;
    }


    public async void AddWeatherForecast()
    {
        IsBusy = true;
        // Simulate asynchronous loading to demonstrate streaming rendering
        await Task.Delay(500);
        
        var startDate = DateOnly.FromDateTime(DateTime.Now);
        var forecast = new WeatherForecast
        {
            Date = startDate.AddDays(WeatherForecastModel.Forecasts.Count + 1),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[Random.Shared.Next(_summaries.Length)]
        };
        WeatherForecastModel.Forecasts.Add(forecast);
        IsBusy = false;
    }
    
    public async void RemoveWeatherForecast()
    {
        IsBusy = true;
        // Simulate asynchronous loading to demonstrate streaming rendering
        await Task.Delay(500);
        
        WeatherForecastModel.Forecasts.RemoveAt(0);
        IsBusy = false;
    }
}

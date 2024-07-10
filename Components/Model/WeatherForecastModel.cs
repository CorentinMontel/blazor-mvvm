using System.Collections.ObjectModel;

namespace BlazorAppMVVM.Components.Model;

public class WeatherForecastModel : BaseModel
{
    private int _collectionLength = 0;

    public int CollectionLength
    {
        get => _collectionLength;
        set
        {
            _collectionLength = value;
            OnPropertyChanged();
        }
    }
    
    // Use Observable collection to make collection reactive
    private ObservableCollection<WeatherForecast> _forecasts = new ();
    
    // When forecast is set, notify change
    public ObservableCollection<WeatherForecast> Forecasts
    {
        get => _forecasts;
        set
        {
            if (_forecasts != value)
            {
                _forecasts = value;
                OnPropertyChanged();
            }
        }
    }
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorAppMVVM.Components.Model;

public class WeatherForecastModel : INotifyPropertyChanged
{
    private ObservableCollection<WeatherForecast> _forecasts = new ();
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

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
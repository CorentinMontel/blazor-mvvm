using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorAppMVVM.Components.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    private bool isBusy = false;
    public bool IsBusy
    {
        get => isBusy; 
        set
        {
            SetValue(ref isBusy, value);
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingField, value)) return; 
        backingField = value;
        OnPropertyChanged(propertyName);
    }
    
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
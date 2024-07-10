using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorAppMVVM.Components.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    private bool _isBusy = false;
    public bool IsBusy
    {
        get => _isBusy;
        protected set => SetValue(ref _isBusy, value);
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null!)
    {
        // New and old value, return if same
        if (EqualityComparer<T>.Default.Equals(backingField, value)) return; 
        backingField = value;
        
        // Notify of property change
        OnPropertyChanged(propertyName);
    }

    private void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
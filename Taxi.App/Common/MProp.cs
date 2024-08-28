﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Taxi.App.Common;

public class MProp<T> : INotifyPropertyChanged
{
    private T _value;
    private string _error;
    private Action onChange;

    public Action OnChange
    {
        set
        {
            onChange = value;
        }
    }
    public string Error
    {
        get => _error;
        set
        {
            _error = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HasError));
        }
    }

    public bool HasError => !string.IsNullOrEmpty(_error);

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            OnPropertyChanged();

            onChange?.Invoke();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

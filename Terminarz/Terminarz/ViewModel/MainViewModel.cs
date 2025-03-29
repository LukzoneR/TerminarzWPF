
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;

namespace Terminarz.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    private DateTime _currentWeekStart;
    public ObservableCollection<string> DaysOfWeek { get; set; }

    private int _currentDayIndex;
    public int CurrentDayIndex
    {
        get => _currentDayIndex;
        set
        {
            _currentDayIndex = value;
            OnPropertyChanged(nameof(CurrentDayIndex));
        }
    }

    public DateTime CurrentWeekStart
    {
        get => _currentWeekStart;
        set
        {
            _currentWeekStart = value;
            OnPropertyChanged(nameof(CurrentWeekStart));
            OnPropertyChanged(nameof(CurrentMonth));
            OnPropertyChanged(nameof(CurrentYear));
            UpdateWeekDays();
        }
    }

    public string CurrentMonth => CurrentWeekStart.ToString("MMMM", CultureInfo.InvariantCulture);
    public string CurrentYear => CurrentWeekStart.Year.ToString();
    public ObservableCollection<string> WeekDays { get; set; }
    public ICommand NextWeekCommand { get; set; }
    public ICommand PreviousWeekCommand { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public MainViewModel()
    {
        _currentWeekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);
        WeekDays = new ObservableCollection<string>();
        DaysOfWeek = new ObservableCollection<string>();
        UpdateWeekDays();

        NextWeekCommand = new RelayCommand(_ => ChangeWeek(7));
        PreviousWeekCommand = new RelayCommand(_ => ChangeWeek(-7));
    }

    private void ChangeWeek(int days)
    {
        CurrentWeekStart = CurrentWeekStart.AddDays(days);
    }

    private void UpdateWeekDays()
    {
        WeekDays.Clear();
        DaysOfWeek.Clear();

        for (int i = 0; i < 7; i++)
        {
            string day = CurrentWeekStart.AddDays(i).ToString("dd");
            WeekDays.Add(day);
            DaysOfWeek.Add(day);
        }
   
        DateTime today = DateTime.Today;
        if (today >= CurrentWeekStart && today < CurrentWeekStart.AddDays(7))
            CurrentDayIndex = (int)(today - CurrentWeekStart).TotalDays;
        else
            CurrentDayIndex = -1; 
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


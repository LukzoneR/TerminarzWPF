using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using Terminarz.Model;

namespace Terminarz.ViewModel;

public class MainViewModel : INotifyPropertyChanged
{
    private DateTime _currentWeekStart;
    public ObservableCollection<string> DaysOfWeek { get; set; }
    public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();
    public ICommand DeleteEventCommand { get; set; }

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

        DeleteEventCommand = new RelayCommand(DeleteEvent);

        LoadEvents();
    }

    private void ChangeWeek(int days)
    {
        CurrentWeekStart = CurrentWeekStart.AddDays(days);
        LoadEvents();
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

    public void LoadEvents()
    {
        Events.Clear();
        using (var db = new AppDbContext())
        {
            DateTime weekStart = CurrentWeekStart;
            DateTime weekEnd = weekStart.AddDays(7);

            var events = db.Events
                .Where(e => e.Starts >= weekStart && e.Starts < weekEnd)
                .AsEnumerable()
                .OrderBy(e => e.Starts)
                .ThenByDescending(e => (e.Ends - e.Starts).TotalHours)
                .ToList();

            foreach (var ev in events)
            {
                Events.Add(ev);
            }
        }
    }


    private void DeleteEvent(object parameter)
    {
        if (parameter is Event eventToDelete)
        {
            using (var db = new AppDbContext())
            {
                var eventInDb = db.Events.FirstOrDefault(e => e.Id == eventToDelete.Id);
                if (eventInDb != null)
                {
                    db.Events.Remove(eventInDb);
                    db.SaveChanges();
                }
            }

            Events.Remove(eventToDelete);
            MessageBox.Show("Event deleted successfully!", "Success",
                          MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}


using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;

namespace Terminarz.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DateTime _currentWeekStart;
        public ObservableCollection<string> DaysOfWeek { get; set; }

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

        public ICommand NextWeekCommand { get; }
        public ICommand PreviousWeekCommand { get; }

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
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<string> GetCurrentWeekDates()
        {
            var today = DateTime.Today;
            int offset = (int)today.DayOfWeek - 1; 
            if (offset == -1) offset = 6; 

            DateTime monday = today.AddDays(-offset);
            return new ObservableCollection<string>
            (
                Enumerable.Range(0, 7).Select(i => monday.AddDays(i).ToString("dd"))
            );
        }
    }
}

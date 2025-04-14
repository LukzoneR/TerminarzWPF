using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Terminarz.View;
using Terminarz.ViewModel;


namespace Terminarz;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainViewModel();  
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        AddEventWindow addEventWindow = new AddEventWindow();
        addEventWindow.ShowDialog();
    }

    private void CalendarButton_Click(object sender, RoutedEventArgs e)
    {
        CalendarPopup.IsOpen = !CalendarPopup.IsOpen;
    }

    private void MiniCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
    {
        if (MiniCalendar.SelectedDate.HasValue)
        {
            var selectedDate = MiniCalendar.SelectedDate.Value;
            CalendarPopup.IsOpen = false;

            if (DataContext is MainViewModel vm)
            {
                int delta = DayOfWeek.Monday - selectedDate.DayOfWeek;
                if (selectedDate.DayOfWeek == DayOfWeek.Sunday) delta = -6;
                vm.CurrentWeekStart = selectedDate.AddDays(delta);
                vm.LoadEvents();
            }
        }
    }
}
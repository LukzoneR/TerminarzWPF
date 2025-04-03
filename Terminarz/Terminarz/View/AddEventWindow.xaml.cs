using System.Windows;
using System.Windows.Media;
using Terminarz.Model;
using MahApps.Metro.Controls;
using Terminarz.ViewModel;

namespace Terminarz.View
{
    public partial class AddEventWindow : MetroWindow
    {
        private string selectedColorHex = "#0000FF";

        public AddEventWindow()
        {
            InitializeComponent();
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                StartDatePicker.SelectedDateTime == null ||
                EndDatePicker.SelectedDateTime == null)
            {
                MessageBox.Show("Fill up required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DateTime startDate = StartDatePicker.SelectedDateTime.Value;
            DateTime endDate = EndDatePicker.SelectedDateTime.Value;

            if (startDate >= endDate)
            {
                MessageBox.Show("Start date has to be earlier than End date", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            using (var db = new AppDbContext())
            {
                var newEvent = new Event
                {
                    Name = NameTextBox.Text,
                    Location = LocationTextBox.Text,
                    Starts = startDate,
                    Ends = endDate,
                    Color = selectedColorHex,
                    Description = DescriptionTextBox.Text
                };

                db.Events.Add(newEvent);
                db.SaveChanges();
            }

            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow?.DataContext is MainViewModel viewModel)
            {
                viewModel.LoadEvents();
            }

            MessageBox.Show("Event Added!");
            this.Close();
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue.HasValue)
                selectedColorHex = e.NewValue.Value.ToString();
        }
    }
}

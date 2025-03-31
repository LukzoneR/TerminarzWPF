using System.Windows;
using Terminarz.Model;

namespace Terminarz.View;

public partial class AddEventWindow : MahApps.Metro.Controls.MetroWindow
{
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
            MessageBox.Show("Fill in the required fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        using (var db = new AppDbContext())
        {
            var newEvent = new Event
            {
                Name = NameTextBox.Text,
                Location = LocationTextBox.Text,
                Starts = StartDatePicker.SelectedDateTime.Value,
                Ends = EndDatePicker.SelectedDateTime.Value,
                Color = ColorTextBox.Text,
                Description = DescriptionTextBox.Text
            };

            db.Events.Add(newEvent);
            db.SaveChanges();
        }

        MessageBox.Show("Event added!");
        this.Close();
    }
}
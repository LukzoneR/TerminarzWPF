using System.Windows;
using System.Windows.Media;
using Terminarz.Model;
using Terminarz.ViewModel;


namespace Terminarz
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            FontFamily customFontFamily = new FontFamily("pack://application:,,,/res/variableFont.ttf#variableFont");
            this.FontFamily = customFontFamily;

            using (var db = new AppDbContext())
            {
                var newEvent = new Event
                {
                    Name = "Spotkanie zespołu",
                    Location = "Sala konferencyjna",
                    Starts = new DateTime(2025, 3, 27, 10, 0, 0),
                    Ends = new DateTime(2025, 3, 27, 12, 0, 0),
                    Color = "Niebieski",
                    Description = "Omówienie postępów projektu"
                };

                db.Events.Add(newEvent);
                db.SaveChanges();
            }

        }
    }
}
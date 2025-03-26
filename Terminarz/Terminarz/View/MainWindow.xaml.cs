using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Terminarz.Model;

namespace Terminarz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

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
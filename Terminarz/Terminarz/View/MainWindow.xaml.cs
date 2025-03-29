using System.Windows;
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

        FontFamily customFontFamily = new FontFamily("pack://application:,,,/res/variableFont.ttf#variableFont");
        this.FontFamily = customFontFamily;  
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        AddEventWindow addEventWindow = new AddEventWindow();
        addEventWindow.ShowDialog();
        LoadEvents();
    }

    private void LoadEvents()
    {
    }

}
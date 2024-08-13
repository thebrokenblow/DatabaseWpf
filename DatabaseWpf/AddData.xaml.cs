using DatabaseWpf.ViewModel;
using System.Windows;

namespace DatabaseWpf;

/// <summary>
/// Логика взаимодействия для AddData.xaml
/// </summary>
public partial class AddData : Window
{
    private readonly UserViewModel userViewModel = new();
    public AddData()
    {
        InitializeComponent();
        DataContext = userViewModel;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var mainWindow = new MainWindow();
        mainWindow.Show();

        Close();
    }
}
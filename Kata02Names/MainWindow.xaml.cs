using System.Windows;

namespace Kata02Names;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow() => InitializeComponent();

    private void AddName_Click(object sender, RoutedEventArgs e)
    {
        string name = TextBoxName.Text;
        if (!string.IsNullOrEmpty(name) && !ListBoxNames.Items.Contains(name))
        {
            ListBoxNames.Items.Add(name);
            TextBoxName.Clear();
        }
    }
}

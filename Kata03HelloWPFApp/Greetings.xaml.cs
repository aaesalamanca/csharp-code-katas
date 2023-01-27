using System.Windows;

namespace Kata03HelloWPFApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Greetings : Window
{
    public Greetings() => InitializeComponent();

    private void Display_Click(object sender, RoutedEventArgs e)
    {
        if (RadioButtonHello.IsChecked == true)
        {
            _ = MessageBox.Show("Hello.");
        }
        else if (RadioButtonGoodbye.IsChecked == true)
        {
            _ = MessageBox.Show("Goodbye.");
        }
    }
}

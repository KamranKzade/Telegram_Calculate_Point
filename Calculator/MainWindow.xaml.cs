using System.Windows;

namespace Calculator;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e) => MessageBox.Show("will be generated in the future", "Information", MessageBoxButton.OK, MessageBoxImage.Information);


}

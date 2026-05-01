using Avalonia.Controls;
using Avalonia.Interactivity;

namespace eBIR_Forms_RE.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void AboutScreenClick(object? sender, RoutedEventArgs e)
    {
        AboutOverlay.IsVisible = true;
    }
    private void AboutScreenClickClose(object? sender, RoutedEventArgs e)
    {
        AboutOverlay.IsVisible = false;
    }
}